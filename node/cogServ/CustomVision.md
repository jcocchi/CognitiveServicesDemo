# Create Your Custom Vision Model #

[Custom Vision Service](https://customvision.ai) is a tool for building custom image classifiers. It makes it easy and fast to build, deploy, and improve an image classifier. For this exercise we'll put together a model to classify pictures of Game of Thrones house sigils. You can find sample images to start with in the `VisionTrainingImages` folder of this repository, and feel free to add your own photos to improve your classifier!

If you don't already have a [Microsoft Account](https://signup.live.com/) (Skype ID, XBox Live, Outlook) please create one in order to sign in to the [customvision.ai](https://customvision.ai) portal. 

## Step 1 - Get started
1. Go to [https://customvision.ai](https://customvision.ai) and log in with your Microsoft Account.
2. Click `New Project` to create your first project.
3. Accept Terms of Service.
4. Add a Name and Description to the project.
5. For this project select `General` as the Domain and click `Create project`.
![NewProject](https://github.com/jcocchi/CognitiveServicesDemo/blob/master/node/cogServ/Screenshots/New%20Project.JPG)

## Step 2 - Add images
1. Upload the images from the `VisionTrainingImages/Lannister` folder and add the tag `Lannister`. 
2. Upload the images from the `VisionTrainingImages/Stark` folder and add the tag `Stark`.
3. Upload the images from the `VisionTrainingImages/Targaryen` folder and add the tag `Targaryen`.
![AddImage](https://github.com/jcocchi/CognitiveServicesDemo/blob/master/node/cogServ/Screenshots/Add%20Image.JPG)
![TagImage](https://github.com/jcocchi/CognitiveServicesDemo/blob/master/node/cogServ/Screenshots/Tag%20Image.JPG)

## Step 3 - Train & test your model
1. Click the Green button labeled `Train` at the top of the page. You will have to retrain your model every time you add or modify any of your images or tags.
2. Look at the Precision and Recall values for each tag to verify that you are satisfied with the accuracy.
3. Test your model by pressing the `Quick Test` button next to Train and entering an image that is not already in your training set.
![Train](https://github.com/jcocchi/CognitiveServicesDemo/blob/master/node/cogServ/Screenshots/Train%20model.JPG)
![Performance](https://github.com/jcocchi/CognitiveServicesDemo/blob/master/node/cogServ/Screenshots/Performance.JPG)

## Step 4 - Save your API keys to access the model from your application
1. Click the `Prediction URL` from the `Performance` tab to view the URL and Prediction Key.
2. Copy the top URL displayed in the top box as well as your Prediction Key to use later on in the workshop.

You are now ready to proceed to Step 1 on the [README](https://github.com/jcocchi/CognitiveServicesDemo/blob/master/node/cogServ/README.md)!
![APIKey](https://github.com/jcocchi/CognitiveServicesDemo/blob/master/node/cogServ/Screenshots/API%20Key.JPG)