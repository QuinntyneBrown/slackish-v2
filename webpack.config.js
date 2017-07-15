const webpack = require('webpack');
const CommonsChunkPlugin = webpack.optimize.CommonsChunkPlugin;
const UglifyJsPlugin = webpack.optimize.UglifyJsPlugin;

module.exports = {
    entry: {
        'vendor': ['./ClientApp/polyfills'],
        'app': './ClientApp/main'
    },
    output: {
        path: __dirname + "/dist",
        filename: "[name].js",
        publicPath: "dist/"
    },
    resolve: {
        extensions: ['.ts', '.css', '.html', '.js']
    },
    module: {
        loaders: [
            {
                test: /\.ts$/,
                use: [{
                    loader: 'awesome-typescript-loader'
                },
                {
                    loader: 'angular2-template-loader'
                }]
            },
            { test: /\.css$/, loader: 'raw-loader' },
            { test: /\.html$/, loaders: ['html-loader'] },
        ]
    },
    plugins: [
         //new UglifyJsPlugin({
         //    beautify: false,
         //    comments: false,
         //    mangle: {
         //        screw_ie8: true,
         //        keep_fnames: true
         //    },
         //    compress: {
         //        screw_ie8: true
         //    }
         //})
    ]
};
