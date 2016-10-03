module.exports = function(grunt) {
    grunt.initConfig({
        watch: {
            typings: {
                files: ['wwwroot/typescripts/**/*.ts'],
                tasks: ['typescript:base'],
                options: {

                }
            }
        },
        typescript: {
            base: {
                src: ['wwwroot/typings/**/*.ts'],
                dest: 'wwwroot/scripts',
                options: {
                    module: 'amd',
                    target: 'es5',
                    basePath: 'wwwroot/typings',
                    sourceMap: true,
                    declaration: true,
                    keepDirectoryHierarchy: true,
                    references: [
                        'typings/**/*.d.ts'
                    ]
                }
            }
        }

    });

    grunt.loadNpmTasks('grunt-typescript');
    grunt.loadNpmTasks('grunt-contrib-watch');

    grunt.registerTask('dev', ['watch:typings']);
    grunt.registerTask('build', ['typescript:base']);
}