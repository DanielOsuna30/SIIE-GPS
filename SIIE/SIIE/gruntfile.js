module.exports = function (grunt) {
    var fileList = ["Scripts/Engine/**/*.js"];

    grunt.initConfig({
        uglify: {
            min: {
                files: [
                    {
                        src: fileList,
                        dest: "Scripts/engine.min.js"
                    }
                ]
            }
        },

    });

    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-uglify');

    grunt.registerTask('default', ['uglify']);


};