<template>
  <el-dialog
    width="600px"
    :visible.sync="visible"
    :before-close="handleModal"
    :close-on-click-modal="false"
    :close-on-press-escape="false">
    <div slot="title">{{addOrEdit === 1?'添加分类':'编辑分类'}}</div> 
    <!-- <div slot="title">添加类型</div> -->
    <div>
      <el-form :label-position="labelPosition" label-width="90px">
        <el-form-item label="用户分类:" size="small">
          <el-input v-model="formData.UserTypeName"></el-input>
        </el-form-item><div class="red">*</div>
        <el-form-item label="分类编号:" size="small">
          <el-input v-model="formData.UserTypeCode"></el-input>
        </el-form-item><div class="red">*</div>
        <el-form-item label="权限管理:" size="small">
          <el-select v-model="formData.ACL" clearable multiple>
            <el-option v-for="item in ACLList" :key="item.ACL" :value="item.ACL" :label="item.ACL"></el-option>
          </el-select>
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
        ACLList:[{ACL:'数据分类'},{ACL:'档案管理'},{ACL:'SPC分析'},{ACL:'增加'},{ACL:'删除'},{ACL:'修改'},{ACL:'查看'},{ACL:'关闭'},],
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
