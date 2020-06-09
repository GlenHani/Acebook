
# AcebookApi
AcebookApi is a web service created in .NET Core 2.1, PostgreSQL 10 &amp; Visual Studio Code on macOS

### Set up

1. Get the [Mac C# SDK version 2.1](https://dotnet.microsoft.com/download/dotnet-core/2.1)
    - At the time of writing, the newest version of the Mac SDK was 3.0, but there were some compatibility issues with the dotnet entity framework
    - If you're feeling brave, give the latest version a try (but don't spend more than 30 mins on it)
2. Verify that you have insalled the SDK by executing `$ dotnet` in your terminal - you should see some output text
3. Get [Visual Studio](https://visualstudio.microsoft.com/)
4. Clone this repo with `$ git clone git@github.com:makersacademy/acebook-csharp-template.git`
5. Open folder AcebookApi in your Visual Studio editor, and double click on `AcebookApi.csproj`
6. Install postgres (if you haven't got it already) with `$ brew install postgresql`
7. Then start postgres with `$ brew services start postgresql`
8. Create your DB with `createdb Acebook`
9. Run the sql migration scripts with `$ dotnet ef database update`
    - If this command fails, you may be using the wrong version of dotnet core
10. Run your server with `$ dotnet watch run`
11. Verify that your server is running by hitting https://localhost:5001/api/post) - you should see some JSON
    
### Skills Checklist

- [ ] I can explain or diagram how data is sent from the browser and returned from the server
- [ ] I can make the application render a c sharp template view
- [ ] I can post create a form that posts data to the server
- [ ] I can use the form to create new DB entries
- [ ] I can add new fields to the model and database
- [ ] I can add automated tests

#### Resources

##### Videos + Github examples
[These videos](https://docs.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code) demonstrate specific aspects of C# development.  The codebase used in the videos is [here](https://github.com/makersacademy/TodoApi).

- navigating-a-csharp.mov
- add-template-csharp.mov (branch add-template-to-view)
- creating-new-todo-items.mov (branch add-items-to-db)
- adding-a-migration.mov (branch add-fields-to-model)
