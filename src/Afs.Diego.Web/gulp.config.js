module.exports = function () {
    var webroot = './wwwroot/',
        bowerDependencies = webroot + "lib",
        scssSourceFolder = webroot + "sass/**/afsdiego.scss",
        scssDestinationFolder = webroot + "css/";

    var config = {
        bowerDest: bowerDependencies,
        webroot: webroot,
        scss: scssSourceFolder,
        scssDest: scssDestinationFolder
    };

    return config;
}
