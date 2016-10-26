module.exports = function () {
    var webroot = './wwwroot/',
        bowerDependencies = webroot + "lib",
        scssSourceFolder = webroot + "sass/**/afsdiego.scss",
        scssDestinationFolder = webroot + "css/",
        appFolder = webroot + "app/";

    var config = {
        bowerDest: bowerDependencies,
        webroot: webroot,
        appFolder: appFolder,
        scss: scssSourceFolder,
        scssDest: scssDestinationFolder,
        ts: appFolder + "**/*.ts",
        js: webroot + "js/**/*.js"
    };

    return config;
}
