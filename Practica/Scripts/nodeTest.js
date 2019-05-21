const express = require('express');
const exp = express();

exp.get('/',
    function() {
        console.log("Hola Mundo");
    });
exp.listen(3000);