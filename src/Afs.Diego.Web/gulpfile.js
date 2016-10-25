"use strict";

var gulp = require('gulp'),
    rimraf = require('rimraf'),
    $ = require('gulp-load-plugins')({ lazy: true }),
    config = require('./gulp.config')();

gulp.task("clean", ["clean:css"]);

gulp.task("clean:css", function (cb) {
    log('Cleaning styles');
    rimraf(config.scssDest, cb);
});

gulp.task('bower', function () {
    log('Installing front end dependencies with bower in ' + config.bowerDest);
    return $.bower()
            .pipe(gulp.dest(config.bowerDest));
});

gulp.task('compile:sass', function () {
    log('Compiling SASS ' + config.scss);
    return gulp
            .src(config.scss)
            .pipe($.sass())
            .pipe(gulp.dest(config.scssDest));
});

function log(msg) {
    if (typeof msg === 'object') {
        for (var item in msg) {
            if (msg.hasOwnProperty(item)) {
                $.util.log($.util.colors.yellow(msg[item]));
            }
        }
    } else {
        $.util.log($.util.colors.yellow(msg));
    }
}