const mongoose = require('mongoose');

const postSchema = mongoose.Schema(
  {
    Name: {type: String, required:true},
    Department: {type: String, required:true},
    PlacedPost: {type: String, required:true}
  }
);

module.exports = mongoose.model('Post', postSchema);
