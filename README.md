# Home Assistant Auto Discover
An application that utilized the Auto Discover feature in Home Assistant to allow you to create, delete and edit Entities from a friendly User Interface.  This project has been started as I found it difficult to add/remove/edit Entities via a MQTT plugin; especilly when you are trying to get a Custom device into Home Assistant.

The MQTT Auto Discovery feature is by far the easiest way to add MQTT Entities to Home Assistant and hopefully this tool will help with that.

The project is very much so in it's earliest stages and so far doesn't even have a UI - but I'm working on this :-)

## Build

### Tests

The Tests application (Class Library) obtains it's credentials for the MQTT Server from an Azure Key Vault.  If you want to replicate this, then you'll need an Azure Key Vault of your own.

Once you have setup the Key Vault, you will need to add an Environment Variable to your PC using the following syntax from a Command Prompt:

```javascript
set KEY_VAULT_NAME=<Your Azure KeyVault name>
```

Alternatively, you can add an Environment Variable to your PC from the "Computer" explorer.  See here for instructions: [How to change environment variables in Windows 10](https://www.architectryan.com/2018/08/31/how-to-change-environment-variables-on-windows-10/)