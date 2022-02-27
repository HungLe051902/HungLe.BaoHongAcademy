<template>
  <div id="sidebar">
    <div id="sidebar__header">BaoHongAcademy</div>
    <div id="sidebar__content">
      <div v-if="isLogin" class="sidebar__user-info">{{ user.userName }}</div>
      <div v-else class="sidebar__content-action">
        <button v-on:click="goToRegister" class="w-100 h-btn h-btn-primary mt-3">
          <img class="icon mr-1" src="@/assets/svg/person-add-outline.svg" alt="" />
          Đăng ký
        </button>
        <button v-on:click="goToLogin" class="w-100 h-btn h-btn-secondary mt-2 mb-3">
          <img class="icon mr-1" src="@/assets/svg/log-in-outline.svg" alt="" />
          Đăng nhập
        </button>
      </div>
      <div class="sidebar__tab mt-4">
        <div class="sidebar__tab-item">
          <img class="icon" src="@/assets/svg/book-outline.svg" alt="" />
          KHÓA HỌC
        </div>
        <div class="sidebar__tab-item">
          <img class="icon" src="@/assets/svg/newspaper-outline.svg" alt="" />
          BÀI VIẾT
        </div>
        <div class="sidebar__tab-item">
          <img class="icon" src="@/assets/svg/help-circle-outline.svg" alt="" />
          HỎI ĐÁP
        </div>
        <div class="sidebar__tab-item">
          <img class="icon" src="@/assets/svg/thumbs-up-outline.svg" alt="" />
          PHẢN HỒI
        </div>
        <div class="sidebar__tab-item">
          <img class="icon" src="@/assets/svg/pricetag-outline.svg" alt="" />
          TAG
        </div>
        <div class="sidebar__tab-item">
          <img class="icon" src="@/assets/svg/accessibility-outline.svg" alt="" />
          ABOUT BAOHONG
        </div>
        <div class="sidebar__tab-item">
          <img class="icon" src="@/assets/svg/people-outline.svg" alt="" />
          FOUNDER
        </div>
        <div class="sidebar__tab-item">
          <img class="icon" src="@/assets/svg/cafe-outline.svg" alt="" />
          TÀI TRỢ
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import AccountMixin from "@/mixins/accountMixin.vue";
import { TOKEN_KEY } from "@/helpers/authenticationHelper.js";
export default {
  mixins: [AccountMixin],
  data() {
    return {
      isLogin: false,
      user: {
        userName: "",
      },
    };
  },
  created() {
    var token = localStorage.getItem(TOKEN_KEY);
    if (token) {
      this.isLogin = true;
      var tokenParser = this.parseJwt(token);
      this.user.userName = tokenParser.user_name;
    }
  },
  methods: {
    parseJwt(token) {
      var base64Url = token.split(".")[1];
      var base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
      var jsonPayload = decodeURIComponent(
        atob(base64)
          .split("")
          .map(function (c) {
            return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
          })
          .join("")
      );
      return JSON.parse(jsonPayload);
    },
  },
};
</script>
<style lang="scss" scoped>
#sidebar {
  width: $sidebar-width;
  height: 100vh;
  background-color: #343a45;
  overflow-y: auto;
  #sidebar__header {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 60px;
    color: #fffafa;
    border-bottom: $border-base;
  }
  #sidebar__content {
    .sidebar__user-info {
      display: flex;
      justify-content: center;
      align-items: center;
      color: $color-white;
      border-bottom: $border-base;
      padding: 20px 0;
    }
    .sidebar__content-action {
      padding: 0 20px;
      font-weight: 500;
      border-bottom: $border-base;
    }
    .sidebar__tab {
      width: 100%;
      .sidebar__tab-item {
        font-weight: 500;
        padding: 8px 20px;
        cursor: pointer;
        color: #c0c0c0;
        img {
          margin-right: 8px;
        }
        &:hover {
          color: $color-primary;
          background-color: #303846;
        }
      }
    }
  }
}
</style>
