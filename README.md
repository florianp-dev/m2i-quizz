# m2i-quizz

Format of the commit message
----------------------------
```
<type>(<scope>): <subject>
```

Any line of the commit message cannot be longer 100 characters! This allows the message to be easier to read on github as well as in various git tools.

### Subject line        
Subject line contains succinct description of the change.

#### Allowed `<type>`
* feat (feature)
* fix (bug fix)
* docs (documentation)
* style (formatting, missing semi colons, …)
* refactor
* test (when adding missing tests)
* chore (maintain)

#### Allowed `<scope>`
Scope could be anything specifying place of the commit change. For example $location, $browser, $compile, $rootScope, ngHref, ngClick, ngView, etc...

#### `<subject>` text
* use imperative, present tense: “change” not “changed” nor “changes”
* don't capitalize first letter
* no dot (.) at the end
