require('dotenv').load()
const request = require('request-promise-native')
const express = require('express')
const router = express.Router()

router.post('/', function (req, res, next) {
  const url = req.body.url

  Promise.all([
    // MAKE CALL TO CUSTOM VISION API
    // callAPI(url)
  ]).then(([response]) => {
    var results = response

    // PARSE THE RESPONSE TO FIND THE HIGHEST PREDICTION
    // const top = parseResponse(results.Predictions)

    // GET THE DATA FOR THE TOP SCORED TAG
    // const data = getTagData(top)

    // RENDER RESULTS
    res.render('results', {
      title: 'Results',
      description: `You entered ${url}`,
      probability: 100
    })
  }).catch(reason => {
    console.log(`Promise was rejected becasue ${reason}`)

    // RENDER AN ERROR MESSAGE
    res.render('results',
      { title: 'Error',
        description: 'Oops something went wrong! Submit another link to try again!',
        probability: 100,
        photo: '/images/Error.jpg'
      })
  })
})

module.exports = router

// =========================================================
// HELPER FUNCTIONS HERE
// =========================================================
