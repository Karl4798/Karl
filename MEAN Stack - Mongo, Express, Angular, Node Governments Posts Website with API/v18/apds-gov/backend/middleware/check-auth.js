// Required imports
const jwt = require('jsonwebtoken');

// So this is run each time a request is made to the server...

module.exports=(req,res,next)=>
{

  // Try authenticate the user, and if the JWT Token is invalid or not available (from the cookie),
  // then throw an error and do not allow access to the resource
  try{

    // Get the token from the cookie
    const token = req.signedCookies.token;

    // Verify the JWT
    jwt.verify(token,'hWmZq4t7w!z%C*F-J@NcRfUjXn2r5u8x/A?D(G+KbPdSgVkYp3s6v9y$B&E)H@Mc');

    console.log("Token Verified successfully");
    next();

  }
  catch(error)
  {
    res.status(401).json({
      message:"Not Authorised to Access this Resource."
    });
  }
};
