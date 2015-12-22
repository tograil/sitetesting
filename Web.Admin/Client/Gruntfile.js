module.exports = function(grunt) {
    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        bundler: {
            bundle: {
                views: ['index.html'],
                bundles: {
                    'css': {
                        type: 'css',
                        files: ['content/css/*.css']
                    },
                    'js': {
                        type: 'js',
                        files: ['scripts/*.js', 'scripts/**/*.js']
                    },
                    'libraryjs': {
                        type: 'js',
                        files: [
                            'library/jquery/dist/jquery.min.js',
                            'library/angular/angular.min.js',
                            'library/angular-route/angular-route.min.js',
                            'library/angular-cookies/angular-cookies.min.js',
                            'library/angular-ui-router/release/angular-ui-router.min.js'
                        ]
                    },
                    'librarycss': {
                        type: 'css',
                        files: [
                            'library/bootstrap/dist/css/bootstrap.min.css',
                            'library/font-awesome/css/font-awesome.min.css',
                            'library/themify-icons/themify-icons.css'
                        ]
                    },
                }
            }
        },
    });

    grunt.loadNpmTasks('grunt-bundler');

    grunt.registerTask('default', ['bundler']);
}
