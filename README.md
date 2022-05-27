# UML Diagram
[link](https://lucid.app/lucidchart/79f9579e-1ca7-4001-b997-ed6370dc4f84/edit?invitationId=inv_7f64af1d-9afa-4cca-b938-6356c8ba8eeb)

# Perfect Commit   
***Don't commit all changes in one message, seperate them by choosing the files are changed.***

- Add specific file 
```git add Commands/CreateProduct/CreateProductCommand.cs```  

- If you want to add only some changes in CreateProductCommand.cs
```git add -p CreateProductCommand.cs``` -p Stands for 'partialy'. Then git will ask you the parts you want to add.

## Perfect commit message
The commit message consists of 2 parts;  

- Subject
- Body

Leave one line space after subject, then git will know that you are typing body now.

* Subject: concise summary of what happened
* Body: more detailed explanation
	* What is now different than before?
	* What's the reason for change?
	* Is there anytingh to watch out for / anything particularly remarkable?

# Branches

## Life-cycles of Branches

### Long running branch (main)
This is the branch will stay from the start to the end of the project.
Do not commit changes to the long running branch(main) directly. First, commit them to the short living branches!

### Short living branches (feature, bug fix, refactoring...)
These branches should be deleted after integration (merge/rebase)

## Branching Strategy
Create a new branch and commit your work to it. After that, it will be merged with 'main' branch.
