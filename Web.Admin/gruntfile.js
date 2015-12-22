/// <binding AfterBuild='build' />
module.exports = function (grunt) {

    grunt.initConfig(
    {
        useminPrepare:
        {
            html: "client/index.html",
            options: {
                dest: "build"
            }
        },
        usemin: { html: "index.html" },
        copy: {
            task0: {
                src: "client/index.html",
                dest: "index.html"
            }
        },
        concat: {
            generated: {
                files: [
                  {
                      dest: '.tmp/concat/js/application.js',
                      src: [
                        'client/scripts/app.js',
                        'client/scripts/routes.js',
                        'client/scripts/services/*.js',
                        'client/scripts/controllers.js'
                      ]
                  }
                ]
            }
        },
        uglify: {
            generated: {
                files: [
                  {
                      dest: 'client/scripts/build/application.js',
                      src: ['.tmp/concat/js/application.js']
                  }
                ]
            }
        }
    });

    /*/grunt.config.set('usemin', {
        cssbase: {
            html: 'index.html',
            css: './client/content/css/*.css'
        }
    });

    grunt.config.set('useminPrepare', {
        cssbase: {
            dest: 'index.html',
            scr: '/client/index.html'    
        }
        
    }
   );*/

    grunt.loadNpmTasks('grunt-contrib-copy');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-usemin');

    grunt.registerTask('build', [
        'copy:task0',
        'useminPrepare',
        'concat',
        'cssmin',
        'uglify',
        'usemin'
    ]);
}
