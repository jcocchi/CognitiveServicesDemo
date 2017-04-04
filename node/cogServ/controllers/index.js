const express = require('express')
const router = express.Router()

/* GET home page. */
router.get('/', function (req, res, next) {
  res.render('index',
    { title: 'Still emotional about the end of The Office?',
      description: 'Us too. Enter the link of a photo to find out which character of The Office you are based on your emotion!' })
})

module.exports = router
