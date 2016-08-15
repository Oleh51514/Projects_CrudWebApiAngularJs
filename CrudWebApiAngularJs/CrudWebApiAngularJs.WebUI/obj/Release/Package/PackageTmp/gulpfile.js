/// <binding BeforeBuild='debugIndex' />
var gulp = require('gulp');
var del = require('del');
var inject = require('gulp-inject');
var uglify = require('gulp-uglify');
var concat = require('gulp-concat');

var gulpWatch = require("gulp-watch");
var less = require("gulp-less");

var injectSourse = [
    './app/modules/app/app.js',
   './app/modules/app/app.js',
    './app/modules/app/config.js',
    './app/**/*.js',
    './app/**/services/*.js',
    './app/common/**/*.js',
    '!app/**/*.min.js',
    './content/**/*.css'
];

var injectSourseRelease = [
   './destRelease/*.js',
   './content/**/*.css'
];
var concatSourseRelease = [
    './appRelease/modules/app/app.js',
    './appRelease/modules/app/config.js',
    './appRelease/**/*.js',
    './appRelease/**/services/*.js',
    './appRelease/common/**/*.js',
    '!app/**/*.min.js',
];

var sourcesThirdParty = [
    // angular
    './wwwroot/lib/angularjs/angular.js',
    './wwwroot/lib/angular-animate/angular-animate.js',
    './wwwroot/lib/angular-sanitize/angular-sanitize.js',
    //
    './wwwroot/lib/underscore/underscore.js',
    // restangular (api)
    './wwwroot/lib/restangular/dist/restangular.js',
    // router
    './wwwroot/lib/angular-route/angular-route.js',
    './wwwroot/lib/angular-ui-router/release/angular-ui-router.js',
    // local storage
    './wwwroot/lib/angular-local-storage/dist/angular-local-storage.js',
    // grid (table)
    './wwwroot/lib/angular-ui-grid/ui-grid.js',
    './wwwroot/lib/angular-ui-grid/ui-grid.js',
    './wwwroot/lib/angular-ui-grid/ui-grid.css',
    './wwwroot/lib/angular-ui-grid/ui-grid.ttf',
    './wwwroot/lib/angular-ui-grid/ui-grid.woff',
    // bootstrap
    './wwwroot/lib/bootstrap/dist/css/bootstrap.css',
    // bootstrap ui
    './wwwroot/lib/angular-bootstrap/ui-bootstrap-tpls.js',
    // notification
    './wwwroot/lib/ng-notify/src/scripts/ng-notify.js',
    './wwwroot/lib/ng-notify/src/styles/ng-notify.css',
    // select (dropdown)    
    './wwwroot/lib/angular-ui-select/dist/select.css',
    './wwwroot/lib/angular-ui-select/dist/select.js',
    // validation
    './wwwroot/lib/valdr/valdr.js',
    './wwwroot/lib/valdr/valdr-message.js'
];

var debugInjectSrcs = [
    './dist/lib/angular.js',
    './dist/lib/valdr.js',
    './dist/lib/valdr-message.js',
    './dist/lib/*.js',
    './dist/lib/*.css'
];

gulp.task('concat', function () {
    return gulp.src(concatSourseRelease)
      .pipe(concat('all.js'))
      .pipe(gulp.dest('./destRelease/js'));
});

gulp.task('uglify', function () {
    gulp.src('./app/**/*.js')
        .pipe(uglify())
        .pipe(gulp.dest('./appRelease/'));
});

gulp.task("less", function () {
    return gulp.src("./content/**/*.less")
        .pipe(less())
        .pipe(gulp.dest("./Content"));
});

gulp.task("watch", function () {
    gulpWatch(["./Content/Less/*.less"], function () { gulp.start("less") });
});


// It deletes all items in the specified directory
gulp.task('clean', function () {
    del.sync(['dist/**/*', 'dist/*'], { force: true })
});

// perform the assembly of external resources in './dist/.....
gulp.task('thirdParty', ['clean'], function () {
    gulp.src(['./wwwroot/lib/bootstrap/dist/fonts/*'])
        .pipe(gulp.dest('./dist/fonts'));
    return gulp.src(sourcesThirdParty)
        .pipe(gulp.dest('./dist/lib'));
});

gulp.task('debugIndex', ['less', 'thirdParty'], function () {

    var target = gulp.src('./index.html');
    var sources = gulp.src(injectSourse, { read: false });
    var libSources = gulp.src(debugInjectSrcs, { read: false });
    return doInject(target, sources, libSources);
});

var doInject = function (target, appSrc, libSrc) {
    var thirdPartyCSS = gulp.src(['./dist/lib/*.css']);
    //inject third-party javascript files
    return target
        .pipe(inject(libSrc, { name: 'thirdparty', addRootSlash: false }))
        //inject third-party css files
        .pipe(inject(thirdPartyCSS, { name: 'thirdpartycss', addRootSlash: false }))
        //inject application files
        .pipe(inject(appSrc, { addRootSlash: false }))
        .pipe(gulp.dest('./'));
};


