<script>
export default {
  methods: {
    /**
     * Go to login view
     */
    goToLogin() {
      try {
        this.$router.push("/login");
      } catch (error) {
        console.log();
      }
    },
    /**
     * Go to register view
     */
    goToRegister() {
      try {
        this.$router.push("/register");
      } catch (error) {
        console.log();
      }
    },
  },
};
</script>
