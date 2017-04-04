const request = require('request-promise-native')
const express = require('express')
const router = express.Router()

// YOUR KEY HERE
var EMOTION_KEY = ''
var EMOTION_URL = 'https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize?subscription-key=' + EMOTION_KEY

router.post('/', function (req, res, next) {
  var url = req.body.url

  Promise.all([
    // MAKE CALL TO COG SERVICES
    // callAPI(url)
  ]).then(([response]) => {
    var results = response

    // PARSE RESULTS HERE
    // var topEmotion = parseResponse(results)

    // DETERMINE WHICH IMAGE TO DISPLAY
    // var suggestion = makeSuggestion(topEmotion)

    // RENDER RESULTS
    // res.render('results',
    //   { title: 'Results',
    //     description: suggestion.description,
    //     photo: suggestion.photo })

    // DELETE ME AFTER UNCOMMENTING ABOVE
    res.render('results', {
      title: 'Results',
      description: 'You entered: ' + url
    })
  }).catch(reason => {
    console.log('Promise was rejected becasue ' + reason)

    // RENDER AN ERROR MESSAGE
    res.render('results',
      { title: 'Error',
        description: 'Oops something went wrong! Please make sure that you submitted the correct image link and that your face is both promienent in the image and unobstructed. Submit another link to try again!',
        photo: '/images/Error.jpg'
      })
  })
})

module.exports = router

// =========================================================
// HELPER FUNCTIONS HERE
// =========================================================
