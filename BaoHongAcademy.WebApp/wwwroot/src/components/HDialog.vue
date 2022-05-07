<template>
  <div v-if="isOpenDialog">
    <el-dialog
      v-model="dialogVisible"
      :title="title"
      :width="width"
      :before-close="handleClose"
    >
      <div class="dialog-content">
        <slot></slot>
      </div>
      <!-- <el-button v-on:click="value++" type="primary" plain>Primary</el-button>
      <p>value: {{ value }}</p> -->

      <template #footer>
        <slot name="dialog-footer">
          <span class="dialog-footer">
            <el-button @click="handleClose">Cancel</el-button>
            <el-button type="primary" @click="handleClose">Confirm</el-button>
          </span>
        </slot>
      </template>
    </el-dialog>
  </div>
</template>
<script>
export default {
  props: {
    isOpenDialog: {
      type: Boolean,
      default: false,
    },
    title: {
      type: String,
      default: "Title",
    },
    width: {
      default: "40%",
    },
  },
  data() {
    return {
      dialogVisible: false,
      value: 1,
    };
  },
  created() {
    this.dialogVisible = this.isOpenDialog;
  },
  watch: {
    isOpenDialog(val) {
      this.dialogVisible = val;
    },
  },
  methods: {
    handleClose() {
      this.dialogVisible = false;
      this.$emit("close-dialog");
    },
  },
};
</script>
<style lang="scss">
.dialog-content {
  color: #000000;
}

.el-dialog__header {
    border-bottom: $border-base;
    height: 60px;
    align-items: center;
}

.el-dialog__close.el-icon {
  font-size: 24px !important;
  font-weight: bold;
  color: #000000 !important;
}
</style>