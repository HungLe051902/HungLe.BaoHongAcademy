<template>
  <div id="register" class="d-flex align-items-center flex-column">
    <Brand />
    <p class="fs20p">Đăng ký tài khoản mới</p>
    <div class="register-form">
      <div class="form-group">
        <label for="exampleInputEmail1">Email address</label>
        <input
          ref="emailInput"
          type="email"
          class="form-control"
          id="register-exampleInputEmail1"
          aria-describedby="emailHelp"
          placeholder="Enter email"
          v-model="email"
        />
        <span class="text-danger">{{ emailError }}</span>
      </div>
      <div class="form-group">
        <label for="exampleInputPassword1">Password</label>
        <input
          type="password"
          class="form-control"
          id="exampleInputPassword1"
          placeholder="Password"
          v-model="password"
        />
        <span class="text-danger">{{ passwordError }}</span>
      </div>
      <div class="form-group">
        <label for="exampleInputPassword2">Retype password</label>
        <input
          type="password"
          class="form-control"
          id="exampleInputPassword2"
          placeholder="Retype Password"
          v-model="passwordConfirmation"
        />
        <span class="text-danger">{{ passwordConfirmationError }}</span>
      </div>
      <button v-on:click="registerUser" class="mt-2 h-btn h-btn-primary w-100">
        Đăng ký
      </button>
      <p class="mt-1">
        Khi đăng ký, bạn đã đồng ý với Điều khoản sử dụng và Chính sách bảo mật của chúng
        tôi.
      </p>
      <div class="center-content flex-column">
        <p class="mb-1">
          Bạn đã có tài khoản?
          <a v-on:click="goToLogin" href="#">Đăng nhập</a>
        </p>
        <a href="">Quên mật khẩu?</a>
      </div>
    </div>
  </div>
</template>
<script>
import Brand from "@/components/Brand";
import AccountMixin from "@/mixins/accountMixin.vue";
import { HTTP } from "@/services/BaseAxios";
import { useField, useForm } from "vee-validate";
import * as yup from "yup";

export default {
  components: {
    Brand,
  },
  setup() {
    // Define a validation schema
    const schema = yup.object({
      email: yup
        .string()
        .required("Email phải được nhập")
        .email("Bạn nhập sai định dạng email"),
      password: yup
        .string()
        .required("Password phải được nhập")
        .min(8, "Password phải có ít nhất 8 ký tự"),
      passwordConfirmation: yup
        .string()
        .oneOf([yup.ref("password"), null], "Mật khẩu phải khớp"),
    });
    // Create a form context with the validation schema
    const { meta, handleSubmit, resetForm } = useForm({
      validationSchema: schema,
    });
    // No need to define rules for fields
    const { value: email, errorMessage: emailError } = useField("email");
    const { value: password, errorMessage: passwordError } = useField("password");
    const {
      value: passwordConfirmation,
      errorMessage: passwordConfirmationError,
    } = useField("passwordConfirmation");
    const onSubmit = handleSubmit(() => {
      //
    });
    return {
      metaValidation: meta,
      onSubmit,
      resetForm,
      email,
      emailError,
      password,
      passwordError,
      passwordConfirmation,
      passwordConfirmationError,
    };
  },
  mounted() {
    // Focus first tab
    var vm = this;
    this.$nextTick(function () {
      setTimeout(function () {
        vm.$refs.emailInput.focus();
      }, 100);
    });
  },
  mixins: [AccountMixin],
  methods: {
    registerUser() {
      try {
        this.onSubmit();
        if (this.metaValidation.valid == false) {
          return;
        }

        HTTP.post("/Accounts/register", {
          UserName: this.email,
          Password: this.password,
        })
          .then((res) => {
            if (res?.data?.Success) {
              if (res.data.AppCode == 200) {
                this.$notify({
                  type: "success", // warn, error, success
                  title: "Thành công",
                  text: "Đăng ký thành công",
                });
                this.resetForm();
              } else if (res.data.AppCode == 409) {
                this.$notify({
                  type: "warn", // warn, error, success
                  title: "Cảnh báo",
                  text: "Email đã được đăng ký",
                });
              } else {
                this.$notify({
                  type: "error", // warn, error, success
                  title: "Lỗi",
                  text: "Có lỗi xảy ra. Vui lòng thử lại!",
                });
              }
            }
          })
          .catch((err) => {
            console.log(err);
          });
      } catch (error) {
        console.log();
      }
    },
  },
};
</script>
<style lang="scss" scoped>
#register {
  padding: 36px 0;
  background-color: $color-bg;
  height: 100vh;
  overflow: auto;
  .register-form {
    width: 500px;
    padding: 24px;
    background-color: $color-white;
    border-radius: $border-radius;
  }
}

::v-deep {
  .brand {
    color: black;
  }
}
</style>
