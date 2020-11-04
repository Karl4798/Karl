// Required imports
const express = require("express");
const router = express.Router();
const bcrypt = require("bcrypt");
const jwt = require('jsonwebtoken');
const sanitizeHtml = require('sanitize-html');
const User = require('../model/user');
const ExpressBrute = require('express-brute');
const store = new ExpressBrute.MemoryStore();
const bruteforce = new ExpressBrute(store);

// Method used to create users
router.post("/signup", bruteforce.prevent, (req, res, next) => {

  // Uses Bcrypt to hash and randomly salt the password
  bcrypt.hash(req.body.password,10)
  .then(hash => {
  const user = new User({
  email: sanitizeHtml(req.body.email, {allowedTags: [ 'b', 'i', 'em', 'strong', 'a' ]}),
  phone: sanitizeHtml(req.body.phone, {allowedTags: [ 'b', 'i', 'em', 'strong', 'a' ]}),
  password: sanitizeHtml(hash, {allowedTags: [ 'b', 'i', 'em', 'strong', 'a' ]})
});

// Console log the created user account - the password will be hashed and randomly salted
console.log(req.body.password, req.body.email, req.body.phone);
  user
    .save()
    .then(result => {
      res.status(201).json({
        message: "User created!",
        result: result
      });
    })
    .catch(err => {
      res.status(500).json({
        error: err
      });
    });
  });
});

router.get("/:email", (req, res, next) => {
  User.find({'email': req.params.email})
  .exec()
    .then(user => {
      if (user) {
        res.status(200).json(user);
      } else {
        res.status(404).json({ message: "Cannot find user." });
      }
    })
    .catch(error => {
      res.status(500).json({
        message: "Retrieving user failed."
      });
    });
});

// Method used to authenticate users
// Brute force prevention used to limit requests to the server
router.post("/login", bruteforce.prevent, (req,res,next)=> {
  let fetchedUser;
  User.findOne({email:req.body.email})
  .then(user=>{
  console.log(user);
  if(!user)
  {
    return res.status(401).json(
  {
    message: "Authentication Failed, try again "
  });
  }
  fetchedUser = user;

  // Compare hashed and salted passwords
  return bcrypt.compare(req.body.password,user.password)
  })
  .then(result=>
  {
    console.log("2",result);
    if(!result)
    {
      return res.status(401).json(
      {
        message: "Authentication Failure "
      });
    }
    
    // Generate a token for the user, which expires in one hour
    const token = jwt.sign({email:fetchedUser.email,
     phone:fetchedUser.phone, userId:fetchedUser._id},
     'hWmZq4t7w!z%C*F-J@NcRfUjXn2r5u8x/A?D(G+KbPdSgVkYp3s6v9y$B&E)H@Mc', {
       expiresIn: '1h',
     });

     let options = {
      maxAge: 3600000,
      httpOnly: true,
      secure: true,
      signed: true,
      path: '/'
    }
  
  console.log(token);

  res.cookie('token', token, options);

  // Set cookie
  res.json({ token });


})
.catch(err =>{
console.log(err);
return res.status(401).json({
    message:"Authentication Failure"
    });
  })
});

// Method used to check validity of user account
// Brute force prevention used to limit requests to the server
router.post("/logincheck", bruteforce.prevent, (req,res,next)=> {
  let fetchedUser;
  User.findOne({email:req.body.email})
  .then(user=>{
  console.log(user);
  if(!user)
  {
    return res.status(401).json(
  {
    message: "Authentication Failed, try again "
  });
  }
  fetchedUser = user;

  // Compare hashed and salted passwords
  return bcrypt.compare(req.body.password, user.password)
  })
  .then(result=>
  {
    console.log("2",result);
    if(!result)
    {
      return res.status(401).json(
      {
        message: "Authentication Failure "
      });
    }

    // Generate a token for the user, which expires in one hour
    const token = jwt.sign({email:fetchedUser.email,
     phone:fetchedUser.phone, userId:fetchedUser._id},
     'hWmZq4t7w!z%C*F-J@NcRfUjXn2r5u8x/A?D(G+KbPdSgVkYp3s6v9y$B&E)H@Mc', {
       expiresIn: '1h',
     });
  
  console.log(token);

  // Set cookie
  res.json({ token });

})
.catch(err =>{
console.log(err);
return res.status(401).json({
    message:"Authentication Failure"
    });
  })
});

module.exports = router;

