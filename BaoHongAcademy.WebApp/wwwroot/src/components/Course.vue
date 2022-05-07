<template>
  <div class="baohong-course">
    <div class="card">
      <img class="card-img-top" src="@/assets/img/img_avatar.png" alt="Card image" />
      <div class="card-body">
        <h4 class="card-title">NodeJS Tutorial</h4>
        <p class="card-text">Lập trình nodejs cùng với 5 dự án thực tế</p>
        <div class="mb-3">
          Vùng tương tác
        </div>
        <div class="mb-3">
          Tác giả
        </div>
        <a href="#" class="btn btn-primary">See Profile</a>
      </div>
    </div>  
  </div>
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
  width: 300px;
  // height: 200px;
  border: $border-base;
  border-radius: $border-radius;
  display: flex;
  flex-wrap: wrap;
}
</style>
