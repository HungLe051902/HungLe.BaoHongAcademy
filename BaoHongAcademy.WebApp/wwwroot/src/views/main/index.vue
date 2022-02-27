<template>
  <div id="main-wrapper">
    <SideBar />
    <div class="main-content">
      <router-view />
    </div>
  </div>
</template>
<script>
import SideBar from "@/layout/sidebar.vue";
export default {
  components: {
    SideBar,
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
    width: calc(100vw - 220px);
    right: 0;
    top: 0;
    bottom: 0;
    position: absolute;
  }
}
</style>
