<template>
  <div class="baohong-course">1</div>
</template>
<script>
export default {
  props: {
    courseContent: {},
  },
};
</script>
<style lang="scss">
.baohong-course {
  min-width: 300px;
  height: 200px;
  border: $border-base;
  border-radius: $border-radius;
  display: flex;
  flex-wrap: wrap;
}
</style>
