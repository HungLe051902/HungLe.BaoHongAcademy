import { HTTP } from "@/services/BaseAxios";

export default {
    async createCourse(course) {
      return HTTP.post("/Courses/create-course", course);
    },
  };
  