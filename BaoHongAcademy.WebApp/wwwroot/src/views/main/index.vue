<template>
  <div id="main-wrapper">
    <SideBar />
    <div class="main-content">
      <Header />
      <router-view />
    </div>
  </div>
</template>
<script>
import SideBar from "@/layout/sidebar.vue";
import Header from "@/layout/Header.vue";
export default {
  components: {
    SideBar,
    Header,
  },
  setup() {},
  mounted() {
    let { isReload } = this.$route.query;
    if (isReload == "true") {
      this.$router.push({ path: "main", query: { isReload: false } });

      setTimeout(function () {
        window.location.reload();
      }, 100);
    }
  },
};
</script>
<style lang="scss" scoped>
#main-wrapper {
  position: absolute;
  top: 0;
  bottom: 0;
  right: 0;
  left: 0;
  .main-content {
    height: 100vh;
    width: calc(100vw - 200px);
    right: 0;
    top: 0;
    bottom: 0;
    position: absolute;
  }
}
</style>
