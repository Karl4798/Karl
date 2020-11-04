const mongoose = require('mongoose');
const { unique } = require('jquery');

const departmentSchema = mongoose.Schema(
  {
    Name: {type: String, required:true, unique: true}
  }
);

module.exports = mongoose.model('Department', departmentSchema);
