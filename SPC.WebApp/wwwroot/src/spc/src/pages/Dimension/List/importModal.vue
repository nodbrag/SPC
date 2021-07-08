<template>
  <el-dialog
    width="600px"
    :visible.sync="visible"
    :before-close="handleModalImport"
    :close-on-click-modal="false"
    :close-on-press-escape="false">
    <div slot="title">导入信息</div>
    <div>
      <el-form :label-position="labelPosition" label-width="90px">
        <el-form-item label="检测信息:" size="small">
          <el-upload
          class='image-uploader'
          :multiple='false'
          :auto-upload='true'
          list-type='text'
          :show-file-list='true'
          :before-upload="beforeUpload"
          :drag='true'
          action=''
          :limit="1"
          :on-exceed="handleExceed"
          :http-request="uploadFile"
          >
            <i class="el-icon-upload"></i>
            <div class="el-upload__text">将文件拖到此处，或<em>点击上传</em></div>
            <div class="el-upload__tip" slot="tip">一次只能上传一个文件，仅限text格式，单文件不超过1MB</div>
          </el-upload>
        </el-form-item>
        <el-form-item label="匹配批号:" size="small">
          <el-select v-model="formData.batchC" clearable placeholder="请选择">
            <el-option
              v-for="item in options"
              :key="item.value"
              :label="item.label"
              :value="item.value">
            </el-option>
          </el-select><div class="red">*</div>
        </el-form-item>
      </el-form>
      <div class="sub-btn">
        <el-button @click="handleModalImport(true)">保存</el-button>
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
    },
    data() {
      return {
        labelPosition: 'left',
        options: [{
          value: '1',
          label: '黄金糕1'
        }, {
          value: '2',
          label: '双皮奶2'
        }, {
          value: '3',
          label: '蚵仔煎3'
        }, {
          value: '4',
          label: '龙须面4'
        }, {
          value: '5',
          label: '北京烤鸭5'
        }],
      };
    },
    methods: {
      // isOperate 代表确认还是取消
      handleModalImport(isOperate) {
        this.$emit('handleModalImport',isOperate)
        // this.$emit('update:visible', false); // 直接修改父组件的属性
      },
      beforeUpload (file) {
        console.log('beforeUpload')
        console.log(file.type)
        const isText = file.type === 'application/vnd.ms-excel'
        const isTextComputer = file.type === 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'
        return (isText | isTextComputer)
      },
      // 上传文件个数超过定义的数量
      handleExceed (files, fileList) {
        this.$message.warning(`当前限制选择 1 个文件，请删除后继续上传`)
      },
      // 上传文件
      uploadFile (item) {
        console.log(item)
        const fileObj = item.file
        // FormData 对象
        const form = new FormData()
        // 文件对象
        form.append('file', fileObj)
        form.append('comId', this.comId)
        console.log(JSON.stringify(form))
        // let formTwo = JSON.stringify(form)
        // EnterAPI.iExcel(form).then(response => {
        //   console.log('MediaAPI.upload')
        //   console.log(response)
        //   this.$message.info('文件：' + fileObj.name + '上传成功')
        // })
      },
    }
  }
</script>