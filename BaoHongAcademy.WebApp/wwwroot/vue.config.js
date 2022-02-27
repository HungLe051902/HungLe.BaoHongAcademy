const optionLoadScss = {
  loaderOptions: {
    sass: {
      additionalData: `@import "@/assets/scss/abstracts/index.scss";`,
      implementation: require("node-sass"),
    },
  },
};

module.exports = {
  css: optionLoadScss,
  configureWebpack: {
    resolve: {
      // .mjs needed for https://github.com/graphql/graphql-js/issues/1272
      extensions: ["*", ".mjs", ".js", ".vue", ".json", ".gql", ".graphql"],
    },
    module: {
      rules: [
        // fixes https://github.com/graphql/graphql-js/issues/1272
        {
          test: /\.mjs$/,
          include: /node_modules/,
          type: "javascript/auto",
        },
      ],
    },
  },
};
