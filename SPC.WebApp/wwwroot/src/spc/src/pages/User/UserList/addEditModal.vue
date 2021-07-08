<template>
  <el-dialog
    width="600px"
    :visible.sync="visible"
    :before-close="handleModal"
    :close-on-click-modal="false"
    :close-on-press-escape="false">
    <div slot="title">{{addOrEdit === 1?'添加用户':'编辑用户'}}</div> 
    <!-- <div slot="title">添加类型</div> -->
    <div>
      <el-form :label-position="labelPosition" label-width="90px">
        <el-form-item label="用户名称:" size="small">
          <el-input v-model="formData.UserTypeCode"></el-input>
        </el-form-item><div class="red">*</div>
        <el-form-item label="用户编号:" size="small">
          <el-input v-model="formData.UserName"></el-input>
        </el-form-item><div class="red">*</div>
        <el-form-item label="用户类型:" size="small">
          <el-select v-model="formData.UserType" clearable multiple>
            <el-option v-for="item in UserTypeList" :key="item.UserType" :value="item.UserType" :label="item.UserType"></el-option>
          </el-select><div class="red">*</div>
        </el-form-item>
      </el-form>
      <div class="sub-btn">
        <el-button @click="handleModal(true, addOrEdit)">确定</el-button>
      </div>
    </div>
  </el-dialog>
</template>
<script>
  export default {
    props: {
      visible: {
        type: Boolean,
        default: false
      },
      formData:Object,
      addOrEdit:Number
    },
    data() {
      return {
        labelPosition: 'left',
        UserTypeList:[{UserType:'管理员'},{UserType:'操作员'}],
      };
    },
    methods: {
      // isOperate 代表确认还是取消, addOrEdit代表添加还是编辑
      handleModal(isOperate, addOrEdit) {
        this.$emit('handleModal',isOperate, addOrEdit)
        // this.$emit('update:visible', false); // 直接修改父组件的属性
      }
    }
  }
</script>
