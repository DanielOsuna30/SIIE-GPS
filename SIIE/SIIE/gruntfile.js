module.exports = function (grunt) {
    var fileList = ["Scripts/Engine/Auth/AuthEngine.js"];//will be generated

    grunt.initConfig({
        uglify: {
            min: {
                files: [
                    {
                        src: fileList,
                        dest: "Scripts/Engine/engine.min.js"
                    }
                ]
            }
        }
    });

    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.registerTask('default', ['uglify']);


};