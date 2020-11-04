const express = require("express");
const router = express.Router();
const sanitizeHtml = require('sanitize-html');
const Post = require('../model/post');
const CheckAuth = require('../middleware/check-auth');

router.post('', CheckAuth, (req,res,next)=>
{
  const posts = new Post(
    {
      Name: sanitizeHtml(req.body.Name, {allowedTags: [ 'b', 'i', 'em', 'strong', 'a' ]}),
      Department: sanitizeHtml(req.body.Department, {allowedTags: [ 'b', 'i', 'em', 'strong', 'a' ]}),
      PlacedPost: sanitizeHtml(req.body.PlacedPost, {allowedTags: [ 'b', 'i', 'em', 'strong', 'a' ]})
    }

  );
  posts.save()
  .then((createdPost)=>
  {
    console.log(createdPost);
    res.status(201).json({
      message: "post successfully created",
      postID: createdPost._id
    });
  }).catch(err =>{
      console.log(err);
      return res.status(406).json({
      message:"Please do not enter HTML tags in the fields."
    });
  });
});

router.get('', CheckAuth, (req,res,next)=>
{
  Post.find().then((documents)=>{
    res.json(
      {
        message: "Posts retrieved from the Server successfully",
        posts:documents
      });
  });
});

router.get("/:id", CheckAuth, (req, res, next) => {
  Post.findById(req.params.id)
    .then(post => {
      if (post) {
        res.status(200).json(post);
      } else {
        res.status(404).json({ message: "Cannot find post." });
      }
    })
    .catch(error => {
      res.status(500).json({
        message: "Retrieving post failed."
      });
    });
});

router.put("/:id", CheckAuth, (req, res, next) => {
  const post = new Post({
    _id: req.body.id,
    Name: sanitizeHtml(req.body.Name, {allowedTags: [ 'b', 'i', 'em', 'strong', 'a' ]}),
    Department: sanitizeHtml(req.body.Department, {allowedTags: [ 'b', 'i', 'em', 'strong', 'a' ]}),
    PlacedPost: sanitizeHtml(req.body.PlacedPost, {allowedTags: [ 'b', 'i', 'em', 'strong', 'a' ]})
  });
  Post.updateOne(
    {
      _id: req.params.id
    },
    post
  ).then(result => {
    res.status(200).json({
      message: "Post had been updated."
    });
  });
});

router.delete('/:id', CheckAuth, (req,res,next)=>
{
  console.log(req.params.id)
  Post.deleteOne({_id: req.params.id})
  .then(result=>
  {
    console.log("Post Deleted from DB");
    res.status(200).json({message: "Post Deleted from Database"});
  });
});

module.exports = router;
