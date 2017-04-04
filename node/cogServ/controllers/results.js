const request = require('request-promise-native')
const parseEmotions = require('../models/emotion.js')

const express = require('express')
const router = express.Router()

var EMOTION_KEY = '6b10ef64bd8e4961a0ee319b443e9166'
var EMOTION_URL = 'https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize?subscription-key=' + EMOTION_KEY

router.post('/', function (req, res, next) {
  var url = req.body.url

  // MAKE CALL TO COG SERVICES
  Promise.all([
    callAPI(url)
  ]).then(([results]) => {
    // PARSE RESULTS HERE
    var topEmotion = parseResponse(results)

    // DETERMINE WHICH IMAGE TO DISPLAY
    var suggestion = makeSuggestion(topEmotion)

    // RENDER RESULTS
    res.render('results',
      { title: 'Results',
        description: suggestion.description,
        photo: suggestion.photo })
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
function callAPI (url) {
 // Call API
  return request.post({
    url: EMOTION_URL,
    json: {'url': url}
  }).then((result) => {
    return result
  })
}

function parseResponse (response) {
  // Create array of emotion values
  var emotions = parseEmotions(response[0].scores)

  // Find top emotion
  var topEmotion = 0
  for (var i = 0; i < 8; i++) {
    if (emotions[i] > emotions[topEmotion]) {
      topEmotion = i
    }
  }

  // Return top emotion
  switch (topEmotion) {
    case 0:
      return 'anger'
    case 1:
      return 'contempt'
    case 2:
      return 'disgust'
    case 3:
      return 'fear'
    case 4:
      return 'happiness'
    case 5:
      return 'neutral'
    case 6:
      return 'sadness'
    case 7:
      return 'surprise'
  }
  return null
}

function makeSuggestion (topEmotion) {
  var link = ''
  var description = ''

  // Decide which image to use based on the emotion passed in
  switch (topEmotion) {
    case 'anger':
      link = '/images/AngryDwight.jpg'
      description = 'You look just as angry as Dwight!'
      break
    case 'contempt':
      link = '/images/Angela.jpg'
      description = 'Your contempt level is reaching Angela levels!'
      break
    case 'disgust':
      link = '/images/Kelly.gif'
      description = 'You look just as disgusted as Kelly!'
      break
    case 'fear':
      link = '/images/Michael.jpg'
      description = 'You might just be just as fearful and superstitous as Michael!'
      break
    case 'happiness':
      link = '/images/JimAndPam.png'
      description = 'You look just as happy as Jim and Pam together!'
      break
    case 'neutral':
      link = '/images/Stanley.jpg'
      description = 'Looking just as neutral as Stanley staring at the camera.'
      break
    case 'sadness':
      link = '/images/SadDwight.jpg'
      description = 'Looking as sad as Dwight today!'
      break
    case 'surprise':
      link = '/images/Jim.jpg'
      description = "You look just as suprised as Jim walking in on Dwight's birthday suprise."
      break
    case '':
      link = '/images/Error.jpg'
      description = 'Oops something went wrong! Please make sure that you submitted the correct image link and that your face is both promienent in the image and unobstructed. Submit another link to try again!'
      break
  }

  // Store suggestion
  var suggestion = {
    photo: link,
    description: description
  }

  return suggestion
}

