<template>
  <div id="baohongacademy-header">
    <div
      class="baohongacademy-header w-100 h-100 d-flex justify-content-between align-items-center px-3"
    >
      <div class=""><b> Học lập trình để PRO</b></div>
      <div class="baohongacademy-header__search">
        <!-- <input :placeholder="searchPlaceholder" type="text" /> -->
        <HInputSearch
          :inputStyles="{ width: '300px' }"
          v-on:getInput="handleSearch"
          :placeholder="searchPlaceholder"
        />
      </div>
      <div class="baohongacademy-header__account">Học lập trình để đi làm</div>
    </div>
  </div>
</template>
<script>
import HInputSearch from "@/components/HInputSearch.vue";
export default {
  components: {
    HInputSearch,
  },
  data() {
    return {
      searchPlaceholder: "Tìm kiếm khóa học, bài viết, video, ...",
    };
  },
  methods: {
    handleSearch(val) {
      console.log(val);
    },
  },
};
</script>
<style lang="scss">
#baohongacademy-header {
  height: 60px;
  width: 100%;
  border-bottom: $border-base;
}
</style>
