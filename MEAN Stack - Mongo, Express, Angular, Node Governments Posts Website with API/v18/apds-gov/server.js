// Required imports
const http = require("https");
const fs = require('fs');
const app = require('./backend/app')

// Creates the server, using the self-signed certificate
const server = http.createServer(
  {
  key: fs.readFileSync('keys/privatekey.pem'),
  cert: fs.readFileSync('keys/certificate.pem')
}, app);

process.env.NODE_TLS_REJECT_UNAUTHORIZED = "0";

// Sets the server port
const port = (process.env.PORT || 3000);
app.set("port", port)

// Listens to requests on the specified port (3000)
server.listen(port);

