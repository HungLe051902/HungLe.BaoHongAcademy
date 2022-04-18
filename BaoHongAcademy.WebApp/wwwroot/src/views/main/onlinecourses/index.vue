<template>
  <div id="baohong-online-courses">
    <div class="w-100 d-flex justify-center">
      <button
        v-on:click="createCourse"
        type="button"
        class="btn btn-secondary my-3 right"
      >
        Tạo khóa học
      </button>
      <!-- <div v-if="isOpenDialog"> -->
      <HDialog
        :isOpenDialog="isOpenDialog"
        title="Tạo khóa học"
        v-on:close-dialog="closeDialog"
      >
        <el-form
          label-width="100px"
          :model="courseData"
          style="max-width: 460px"
          label-position="left"
        >
          <el-form-item label="Tiêu đề">
            <el-input v-model="courseData.title" />
          </el-form-item>
          <el-form-item label="Mô tả">
            <el-input v-model="courseData.description" />
          </el-form-item>
          <el-form-item label="Tác giả">
            <el-input v-model="courseData.author" />
          </el-form-item>
        </el-form>
        <template v-slot:dialog-footer>
          <el-button @click="closeDialog">Hủy</el-button>
          <el-button @click="handleCreateCourse" type="primary">Xác nhận</el-button>
        </template>
      </HDialog>

      <!-- </div> -->
    </div>
    <div class="row d-flex justify-between">
      <div v-for="(course, index) in listCourse" :key="index">
        <div class="online-course-wrapper">
          <Course :courseContent="course" />
        </div>
      </div>
    </div>
  </div>
</template>
<script >
import Course from "@/components/Course";
import HDialog from "@/components/HDialog";
import ServiceCourse from "@/services/courseService.js"
import { reactive } from "vue";

export default {
  components: {
    Course,
    HDialog,
  },
  setup() {
    const courseData = reactive({
      title: "",
      description: "",
      author: "",
    });
    return { courseData };
  },
  data() {
    return {
      listCourse: [],
      isOpenDialog: false,
    };
  },
  created() {
    for (let i = 0; i < 20; i++) {
      this.listCourse.push({});
    }
  },
  methods: {
    createCourse() {
      this.isOpenDialog = true;
    },
    closeDialog() {
      this.isOpenDialog = false;
    },
    handleCreateCourse() {
      ServiceCourse.createCourse({ CourseName: this.courseData.title, CourseDescription: this.courseData.description, Author: this.courseData.author })
      // console.log(this.courseData, this.courseData.name);
    }
  },
};
</script>
<style lang="scss">
#baohong-online-courses {
  .online-course-wrapper {
    margin-bottom: 16px;
    margin-left: 15px;
  }
}
</style> lang="scss">
