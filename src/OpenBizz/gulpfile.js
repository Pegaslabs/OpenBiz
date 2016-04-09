/// <binding AfterBuild='sass' ProjectOpened='sass:watch' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var sass = require('gulp-sass');
var paths = {
  webroot: "./webroot"
};

//where to find sass code
paths.sassSource = paths.webroot + "lib/datatables-scroller/scss/*.scss";

//where to output compiled CSS code
paths.cssOutput = paths.webroot + "lib/datatables-scroller/css";

gulp.task('default', function () {
    // place code for your default task here
});

//sass compiler
gulp.task('sass', function () {
  gulp.src(paths.sassSource)
      .pipe(sass().on('error', sass.logError))
      .pipe(gulp.dest(paths.cssOutput));
});

//Watch task
gulp.task('sass:watch', function () {
  gulp.watch(paths.sassSource, ['sass', 'min:css']);
});