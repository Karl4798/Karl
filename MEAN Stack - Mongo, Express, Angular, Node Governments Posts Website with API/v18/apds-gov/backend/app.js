// Required Imports
const express = require('express');
const helmet = require('helmet')
const app = express();
const bodyParser = require('body-parser');
const postRoutes = require("./routes/posts");
const departmentRoutes = require("./routes/departments");
const userRoutes = require("./routes/users");
const mongoose = require('mongoose');
const morgan = require('morgan');
const cookieParser = require('cookie-parser');
const rfs = require('rotating-file-stream');
const fs = require('fs');
var path = require('path');
const rateLimit = require("express-rate-limit");
const cert = fs.readFileSync('keys/certificate.pem');
const cors = require('cors');
const jwt = require('jsonwebtoken');
const options = {
  server: { sslCA: cert}};

  // Create rotating log - every day a new log file will be generated in the \log directory
const accessLogStream = rfs.createStream('access.log', {
  interval: '1d', // rotate logs daily
  path: path.join(__dirname, 'log')
});

// Use Morgan logger to log all API calls
app.use(morgan('combined', { stream: accessLogStream }));

// Cookie Parser used to send and receive secure cookies - secure key below
app.use(cookieParser("SECRET_COOKIE_KEY_ONLY_MIKE_PENCE_HAS_ACCESS_TO"));

// Uses cors to tell browsers to give the web app running at one origin, access to selected resources from different origins.
app.use(cors());

// Uses Helmet middleware to secure the site
app.use(helmet());

// Uses Helmet middleware to prevent clickjacking
app.use(
  helmet({
    frameguard: {
      action: "deny",
    },
  })
);

// Trusts the proxy that was created to route API requests from port 4200 to port 3000
app.set('trust proxy', 1);

const limiter = rateLimit({
  windowMs: 15 * 60 * 1000, // 15 minutes
  max: 100 // limit each IP to 100 requests per windowMs
});

// Middleware used to rate limit API calls
app.use(limiter);

// Conntects to the MongoDB database
mongoose.connect("mongodb+srv://Karl:VHl0MLhuWt2kL899@cluster0-ozwmp.mongodb.net/post-system?retryWrites=true&w=majority")
.then(()=>
{
  console.log("The database has been connected successfully.")
})
.catch(()=>
{
  console.log("The database cannot be reached!")
}, options);

app.use(bodyParser.json());

// Set HTTP response headers - restrict access to resorces
app.use((reg,res,next)=>
{
  res.setHeader("Access-Control-Allow-Origin", "*");
  res.setHeader("Access-Control-Allow-Headers",
                "Origin, X-Requested-With, Content-Type, Accept, Authorization");
  res.setHeader("Access-Control-Allow-Methods",
                "GET, POST, PATCH, PUT, DELETE, OPTIONS");
  next();
});

// Logs the user out by deleting and invalidating thier cookie
app.use('/api/logout', function(req, res) {
  let options = {
    maxAge: -1,
    httpOnly: true,
    signed: true
}

// Delete cookie
res.cookie('token', '', options);
res.send('');
});

// Gets the cookie containing the JWT
app.use('/api/getcookie', function(req, res) {
  const token = req.signedCookies.token;
  res.json({ token });
});

app.use("/api/email", (req, res) => {

  // Get the token from the cookie
  const token = req.signedCookies.token;

  // Verify the JWT
  const jwttoken = jwt.verify(token,'hWmZq4t7w!z%C*F-J@NcRfUjXn2r5u8x/A?D(G+KbPdSgVkYp3s6v9y$B&E)H@Mc');
  
  // Return the email
  res.json(jwttoken.email);

});

// Routes required for users, posts, and departments
app.use("/api/posts", postRoutes);
app.use("/api/departments", departmentRoutes);
app.use("/api/users", userRoutes);

module.exports = app;
