const BrowserSyncPlugin = require('browser-sync-webpack-plugin')
const ExtractTextPlugin = require('extract-text-webpack-plugin')
const HtmlWebpackPlugin = require('html-webpack-plugin')

const PurifyCSSPlugin = require('purifycss-webpack')
const path = require('path')
const glob = require('glob-all')

module.exports = {
    entry: './src/main.js',
    resolve: {
        modules: [
            /* assuming that one up is where your node_modules sit,
               relative to the currently executing script
            */
            path.join(__dirname, '../node_modules')
        ]
    },
    output: {
        path: __dirname + '/dist/',
        filename: 'js/main.bundle.js'
    },
    module: {
        "rules": [
            {
                "enforce": "pre",
                "test": /\.js$/,
                "loader": "source-map-loader",
                "exclude": [

                    path.join(process.cwd(), 'node_modules')
                ]
            }
        ],
        loaders: [
            {
                test: /\.scss$/,
                use: ExtractTextPlugin.extract([
                    {
                        loader: "css-loader",
                        options: {
                            importLoaders: 1,
                            sourceMap: true
                        }
                    },
                    { loader: 'resolve-url-loader', options: { removeCR: true } },
                    { loader: "adjust-sourcemap-loader", options: { debug: true } },
                    { loader: "sass-loader", options: { sourceMap: true } }
                ])
            },

            {
                test: /\.(png|jpg|gif|svg)$/,
                use: [
                    {
                        loader: 'file-loader',
                        options: {
                            outputPath: 'img'
                        }
                    }
                ]
            }
        ]
    },
    plugins: [
        new ExtractTextPlugin('css/style.css'),
        new BrowserSyncPlugin({
            host: 'localhost',
            port: 3000,
            server: { baseDir: ['dist'] },
            files: ['./dist/*', '**/*.html']
        }),
        new HtmlWebpackPlugin({
            title: 'My App',
            template: 'src/index.html',
            filename: 'index.html'
        }),
        new PurifyCSSPlugin({
            paths: glob.sync([
                path.join(__dirname, 'src/*.html'),
                path.join(__dirname, 'src/*.js')
            ]),
            minimize: true,
            purifyOptions: {
                whitelist: []
            }
        })
    ],
    watch: true,
    devtool: 'source-map'
}
