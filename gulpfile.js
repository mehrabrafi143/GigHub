var gulp = require('gulp');
less = require('gulp-less');
watch = require('gulp-watch');
autoprefixer = require('autoprefixer');


gulp.task('less', function () {
    return gulp.src('Content/site.less')
        .pipe(less([autoprefixer()]))
         .on('error',function (error) {
            console.log(error.toString());
                this.emit('end');
         })
        .pipe(gulp.dest('Content/css/'));
});

gulp.task('html',function() {
});

gulp.task('watch', function () {

    watch('Content/Modules/*.less',
        function() {
            gulp.start('less');
        }); 

    watch('Views/**/*.cshtml',
        function () {
            gulp.start('html');
        }); 

});