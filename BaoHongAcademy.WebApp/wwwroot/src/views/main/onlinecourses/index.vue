<template>
  <div id="baohong-online-courses">
    <div class="w-100 d-flex justify-center">
      <button type="button" class="btn btn-secondary my-3 right">
        Tạo khóa học
      </button>
    </div>

    <div class="row d-flex justify-between">
      <div v-for="(course, index) in listCourse" :key="index">
        <div class="online-course-wrapper col-sm-12 col-md-6 col-lg-4 col-xl-3">
          <Course :courseContent="course" />
        </div>
      </div>
    </div>
  </div>
</template>
<script >
import Course from "@/components/Course";
export default {
  components: {
    Course,
  },
  data() {
    return {
      listCourse: [],
    };
  },
  created() {
    for (let i = 0; i < 20; i++) {
      this.listCourse.push({});
    }
  },
};
</script>
<style lang="scss">
#baohong-online-courses {
  .online-course-wrapper {
    margin-bottom: 16px;
  }
}
</style> lang="scss">
