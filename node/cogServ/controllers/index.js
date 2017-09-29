const express = require('express')
const router = express.Router()

/* GET home page. */
router.get('/', function (req, res, next) {
  res.render('index',
    { title: 'Can\'t wait another 2 years for Game of Thrones to come back?',
      description: 'We can\'t either. Enter the link of a photo to find out if you belong in House Stark, House Lannister, or House Targaryen!' })
})

module.exports = router
