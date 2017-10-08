# Cognitive Services Demo - ASP.NET Core

## Step 0 - Prerequisites
If you don't already have an Emotion API key, follow [these README instructions](https://github.com/jcocchi/CognitiveServicesDemo/blob/master/dotnet/EmotionRecognition.md) to get your key.

For this workshop you will need to have [.NET Core](https://www.microsoft.com/net/download/core) installed as well as any text editor- my favorite is [Visual Studio Code](https://code.visualstudio.com/download).

Fork, clone, or download this repository. From the command line, navigate to the `[YOUR INSTALL LOCATION]/CognitiveServicesDemo/dotnet` directory. First we need to bring in all of our project dependencies by entering `dotnet restore`. To see the starting point for our project, run it by entering `dotnet run` and navigating to `http://localhost:5000/` in your browser.

```terminal
  cd [YOUR INSTALL LOCATION]/CognitiveServicesDemo/dotnet
  dotnet restore
  dotnet run
```

> Note: From here on, all file paths are relative to `[YOUR INSTALL LOCATION]/CognitiveServicesDemo/dotnet/`

## Step 1 - Make the API call
1. Uncomment `var results = await MakeRequest(submittedPhoto);` on line 29 of `Controllers/HomeController.cs`
2. Copy the contents of `CodeSnippets/MakeRequest.txt` and paste them in `Controllers/HomeController.cs` under the "Helper Functions Here" comment on line 64
3. Paste your Emotion API key from step 0 where it says `{Your subscription key here}` on the fourth line of the `MakeRequest` function we just copied. It should look like this `client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "1234");` where 1234 is your key
4. Put a breakpoint on line 29 where we store the results to a variable, and then run the project
5. Navigate to `http://localhost:5000/`, enter the URL of a photo and hit enter

After you step over the breakpoint, you should see the JSON returned by Cognitive Services as a string stored in the `results` variable. Press continue in your debugger to execute the rest of the function. Our page still hasn't changed and we won't see our results yet.

## Step 2 - Parse Results to find the top emotion
1. Uncomment `var topEmotion = ParseResults(results);` on line 32 of `Controllers/HomeController.cs`
2. Copy the contents of `CodeSnippets/ParseResponse.txt` and paste them in `Controllers/HomeController.cs` under the `MakeRequest` function we pasted in step 1
3. Replace the existing `Max()` function in the `Scores` class with the contents of `CodeSnippets/TopEmotion.txt` in the `Models/EmotionSet.cs` file
4. Put a breakpoint on line 32 where we store the top emotion to a variable, and then run the project
5. Navigate to `http://localhost:5000/`, enter the URL of a photo and hit enter

After you step over the breakpoint, you should see the top emotion from the photo stored in the `topEmotion` variable. Press continue in your debugger to execute the rest of the function. Our page still hasn't changed and we won't see our results yet.

## Step 3 - Display the results
1. Uncomment `var suggestion = MakeSuggestion(topEmotion);` on line 35 of `Controllers/HomeController.cs`
2. Copy the contents of `CodeSnippets/MakeSuggestion.txt` and paste them in `Controllers/HomeController.cs` under the `ParseResponse` function we pasted in step 2
3. Delete the temporary `return View();` on line 41
4. Uncomment `return RedirectToAction("Results", suggestion);` on line 38 to display the results to our site
5. Run the project and navigate to `http://localhost:5000/`, enter the URL of a photo and hit enter

Now our site is complete. When you enter the URL of a photo you should see an image of someone from The Office as well as a description based on the top emotion in the photo. Try it with different photos to see what you get!

## Step 4 - Customize your site
Feel free to customize your site however you want! Change the theme, modify the suggestion to be based off of the lowest emotion score, or add another API call to make your site even smarter.

> Note: All static files are stored in the `wwwroot/` folder. To add your own images, put them in the `wwwroot/images/` folder and change the links in the `MakeSuggestion` function from step 3.
