function parseEmotions (inputScores) {
  var scores = [
    inputScores.anger,
    inputScores.contempt,
    inputScores.disgust,
    inputScores.fear,
    inputScores.happiness,
    inputScores.neutral,
    inputScores.sadness,
    inputScores.surprise
  ]

  return scores
}

module.exports = parseEmotions
