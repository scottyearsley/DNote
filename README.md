# DNote

## Aims of the project

* A simple, but fast to access developer note editor and tools
* Allow basic note taking using Markdown
* Create named TODO lists
* Capture code snippets which are highlighted and can be re-formatted
* Common developer tools such as:
  * UUID generator
  * Formatted Datetime generator
  * JSON Formatter
* Cross-platform - Windows, Web
* Offline access

## Architecture

* Shared Blazor components for Windows host and Web
* Azure Functions for CRUD API
* Azure CosmosDB for note/list storage
* Auth0 authentication

## Shortcut

To activate the editor and bring it into view press `ALT + N`
