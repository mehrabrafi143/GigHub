const path = require('path');

module.exports = {
    entry: './Scripts/app/app.js',
    output: {
        path: path.resolve(__dirname, './Scripts/'),
        filename: 'app.js'
    }
};