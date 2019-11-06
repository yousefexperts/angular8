/// <reference path="jqwidgets.d.ts" />
function createValidatorFields(sendButtonSelector, acceptSelector, testFormSelector, ItemName, jqxDateTimeInput, MaxNum, MinNum) {
    var sendButtonOptions = {
        width: 60,
        height: 25
    };
    var sendButtonInstance = jqwidgets.createInstance(sendButtonSelector, 'jqxButton', sendButtonOptions);
    var acceptInputOptions = {
        width: 130
    };
     var acceptInputInstance = jqwidgets.createInstance(acceptSelector, 'jqxCheckBox', acceptInputOptions);
     
    var inputOptions = { width: 150, height: 22 };
    var itemNameInstance = jqwidgets.createInstance(ItemName, 'jqxInput', inputOptions);
    var minNumInstance = jqwidgets.createInstance(MinNum, 'jqxInput', inputOptions);
    var maxNumInstance = jqwidgets.createInstance(MaxNum, 'jqxInput', inputOptions);

    var dateTimeInputOptions = {
        width: 150,
        height: 22
    };
    var dateTimeInputInstance = jqwidgets.createInstance(jqxDateTimeInput, 'jqxDateTimeInput', dateTimeInputOptions);
    var validatorOptions = {
        rules: [
            {
                input: itemNameInstance,
                message: 'itemName is required!',
                action: 'keyup, blur, click',
                rule: 'required'
            },
            {
                input: minNumInstance,
                message: 'minNum is required!',
                action: 'keyup, blur, click',
                rule: 'required'
            },
            {
                input: maxNumInstance,
                message: 'maxNum is required!',
                action: 'keyup, blur, click',
                rule: 'required'
            },
            {
                input: dateTimeInputInstance,
                message: 'dateTime is required!',
                action: 'keyup, blur, click',
                rule: 'required'
            },
            {
                input: acceptInputInstance,
                message: 'You have to accept the terms',
                action: 'change',
                rule: 'required',
                position: 'right:0,0'
            }]
    };
    var validatorInstance = jqwidgets.createInstance(testFormSelector, 'jqxValidator', validatorOptions);
    sendButtonInstance.addEventHandler('click', function () {
        validatorInstance.validate;
    });
}
//# sourceMappingURL=typescript-validator.js.map
