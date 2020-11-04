const express = require("express");
const router = express.Router();
const sanitizeHtml = require('sanitize-html');
const Department = require('../model/department');
const CheckAuth = require('../middleware/check-auth');

router.post('', CheckAuth, (req,res,next)=>
{
  const departments = new Department(
    {
      Name: sanitizeHtml(req.body.Name, {allowedTags: [ 'b', 'i', 'em', 'strong', 'a' ]})
    }

  );
  departments.save()
  .then((createdDepartment)=>
  {
    console.log(createdDepartment);
    res.status(201).json({
      message: "department successfully created",
      departmentID: createdDepartment._id
    });
    console.log(departments)
  }).catch(err =>{
      console.log(err);
      return res.status(406).json({
      message:"Please do not enter HTML tags in the fields."
    });
  });
});

router.get('', CheckAuth, (req,res,next)=>
{
  Department.find().then((documents)=>{
    res.json(
      {
        message: "Departments retrieved from the Server successfully",
        departments:documents
      });
  });
});

router.get("/:id", CheckAuth, (req, res, next) => {
  Department.findById(req.params.id)
    .then(department => {
      if (department) {
        res.status(200).json(department);
      } else {
        res.status(404).json({ message: "Cannot find department." });
      }
    })
    .catch(error => {
      res.status(500).json({
        message: "Retrieving department failed."
      });
    });
});

router.put("/:id", CheckAuth, (req, res, next) => {
  const department = new Department({
    _id: req.body.id,
    Name: sanitizeHtml(req.body.Name, {allowedTags: [ 'b', 'i', 'em', 'strong', 'a' ]})
  });
  Department.updateOne(
    {
      _id: req.params.id
    },
    department
  ).then(result => {
    res.status(200).json({
      message: "Department had been updated."
    });
  });
});

router.delete('/:id', CheckAuth, (req,res,next)=>
{
  console.log(req.params.id)
  Department.deleteOne({_id: req.params.id})
  .then(result=>
  {
    console.log("Department Deleted from DB");
    res.status(200).json({message: "Department Deleted from Database"});
  });
});

module.exports = router;
