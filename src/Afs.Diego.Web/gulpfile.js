"use strict";

var gulp = require('gulp'),
    rimraf = require('rimraf'),
    $ = require('gulp-load-plugins')({ lazy: true }),
    config = require('./gulp.config')();

gulp.task("clean", ["clean:css", "clean:js"]);

gulp.task("clean:css", function (cb) {
    log('Cleaning styles');
    rimraf(config.scssDest, cb);
});

gulp.task("clean:js", function (cb) {
    rimraf(config.js, cb);
});

gulp.task('bower', function () {
    log('Installing front end dependencies with bower in ' + config.bowerDest);
    return $.bower()
            .pipe(gulp.dest(config.bowerDest));
});

gulp.task("compile", ["compile:sass", "compile:ts"]);

gulp.task('compile:sass', function () {
    log('Compiling SASS ' + config.scss);
    return gulp
            .src(config.scss)
            .pipe($.sass())
            .pipe(gulp.dest(config.scssDest));
});

gulp.task('compile:ts', function () {
    log('Compiling Typescript to Javascript...');

    return gulp
        .src(config.ts)
        .pipe($.sourcemaps.init())
        .pipe($.typescript({
            noImplicitAny: true,
            target: 'ES5'
        }))
        .pipe($.sourcemaps.write('.'))
        .pipe(gulp.dest(config.appFolder));
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