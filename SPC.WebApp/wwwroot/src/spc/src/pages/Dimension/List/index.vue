<!--<template>
    <div>
        <div class="box_table">
            <TableToolBar :formData="formSearch"  @addModal="addModal(1)">
                <el-form-item slot="input">
                    <el-input
                              size="mini"
                              placeholder="批号"
                              v-model="formSearch.batchC">
                    </el-input>
                </el-form-item>
                <el-form-item slot="input">
                    <el-date-picker
                        v-model="formSearch.starttime"
                        type="date"
                        placeholder="开始时间">
                    </el-date-picker>
                </el-form-item>
                <el-form-item slot="input">
                    <el-date-picker
                        v-model="formSearch.endtime"
                        type="date"
                        placeholder="结束时间">
                    </el-date-picker>
                </el-form-item>
                <div slot="import" class="box_import">
                    <el-button type="primary" icon="el-icon-circle-plus-outline" size="mini" @click="importModal">导入</el-button>
                </div>
            </TableToolBar>
            <el-table
                :data="tableData.filter(data => !search || data.batch.toLowerCase().includes(search.toLowerCase()))"
                :default-sort = "{prop: 'number', order: 'descending'}"
                stripe
                :cell-style="cellStyle"
                style="width: 100%">
                <el-table-column
                label="批号C"
                prop="batchC">
                </el-table-column>
                <el-table-column
                label="产品名称"
                prop="productName">
                </el-table-column>
                <el-table-column
                label="检测机号"
                prop="testingMachineNumber">
                </el-table-column>
                <el-table-column
                label="检测时间"
                prop="testingTime" width="280px">
                </el-table-column>
                <el-table-column
                label="产品数量"
                prop="productQuantity">
                </el-table-column>
                <el-table-column
                label="不良数量"
                prop="badQuantity">
                </el-table-column>
                <el-table-column
                label="整形机号"
                prop="shapingMachineNumbe">
                </el-table-column>
                <el-table-column
                label="操作">
                    <template slot-scope="scope">
                        <el-dropdown>
                            <span class="el-dropdown-link">
                                <i class="el-icon-caret-bottom el-icon--right"></i>   详细
                            </span>
                            <el-dropdown-menu slot="dropdown">
                                <el-dropdown-item><span @click="handleEdit(scope.$index, scope.row)">编辑</span></el-dropdown-item>
                                <el-dropdown-item><span  @click="handleDelete(scope.$index, scope.row)">删除</span></el-dropdown-item>
                            </el-dropdown-menu>
                        </el-dropdown>
                    </template>
                </el-table-column>
            </el-table>
            <Pagination></Pagination>
        </div>

        <addEditModal v-show="addVisible" :visible.sync="addVisible" :addOrEdit="addOrEdit" :formData="addOrEdit===1?{}:formModal" @handleModal="handleModal(arguments)" />

        <delModal v-show="delVisible" :visible.sync="delVisible" :rowId="rowId" @handleModalDel="handleModalDel(arguments)"></delModal>

        <importListModal v-show="importVisible" :visible.sync="importVisible" :formData="formBatchModal" @handleModalImport="handleModalImport(arguments)"></importListModal>
    </div>
</template>
<script>
import TableToolBar from '../../../components/TableToolBar/TableToolBar.vue'
import addEditModal from './addEditModal.vue'
import importListModal from './importModal.vue'
import delModal from '../../../components/ModalDelete/ModalDelete.vue'
import Pagination from '../../../components/Pagination/Pagination.vue'
export default {
    data() {
        return {
            // tableToolBar的信息
            formSearch: {
                batchC:'',
                starttime:'',
                endtime:'',
            },
            search:'',
            // 表格的信息
            tableData: [
                {
                batchC: 'APB-091',
                productName: '手机配件',
                testingMachineNumber:'LH-801',
                testingTime:'2019/05/09 08:00:00---2019/05/09 09:00:00',
                productQuantity:'134,100',
                badQuantity:'1130',
                shapingMachineNumbe:'LH-801',
                },
                {
                batchC: 'APB-091',
                productName: '手机配件',
                testingMachineNumber:'LH-801',
                testingTime:'2019/05/09 08:00:00---2019/05/09 09:00:00',
                productQuantity:'134,100',
                badQuantity:'1130',
                shapingMachineNumbe:'LH-801',
                },
                {
                batchC: 'APB-091',
                productName: '手机配件',
                testingMachineNumber:'LH-801',
                testingTime:'2019/05/09 08:00:00---2019/05/09 09:00:00',
                productQuantity:'134,100',
                badQuantity:'1130',
                shapingMachineNumbe:'LH-801',
                }
            ],
            // 弹框的信息
            formModal: {
                batchC:'APB-091',
                productName:'手机配件',
                testingMachineNumber:'LH-801',
                plasticTime:'2019/05/09 08:00:00---2019/05/09 09:00:00',
                productQuantity:'134,100',
                badQuantity:'1130',
                shapingMachineNumbe:'LH-801',
            },
            //导入时选择的批号
            formBatchModal: {
                batchC:'APB-091',
            },
            addVisible: false, // 弹框是否显示,
            delVisible: false, // 删除弹框是否显示
            importVisible: false, // 导入弹框是否显示
            // 当前编辑的index
            rowId:0,
            // addOrEdit 确认添加还是编辑 1表示添加 2表示编辑
            addOrEdit: 1
        }
    },
    methods: {
        // 表格列颜色样式
        cellStyle(data){
            // if(data.columnIndex==6){
            //     return 'background:rgba(179,179,179,0.245)'
            // }
        },
        // 点击操作按钮的 编辑
        handleEdit(index, row) {
            this.rowId = index
            this.addOrEdit = 2
            this.addVisible = true
        },
        // 点击操作按钮的 删除
        handleDelete(index, row) {
            this.rowId = index
            this.delVisible = true
        },
        // 点击添加按钮
        addModal () {
            this.addOrEdit = 1
            this.addVisible = true;
        },
        // 点击导入按钮
        importModal () {
            this.importVisible = true;
        },
        // 点击添加编辑弹框的 确认和取消
        handleModal(param){
            if(param[0]) {
                if(param[1] === 1) {
                    console.log('添加成功')
                } else if(param[1] === 2) {
                    console.log('编辑成功')
                }
            } else {
                console.log('失败')
            }
            this.addVisible = false
        },
        // 点击删除弹框的 确认和取消
        handleModalDel (param){
            if(param[0]) {
                console.log('删除成功',this.rowId)
            } else {
                console.log('删除失败')
            }
            this.delVisible = false
        },
        // 点击导入弹框的 确认和取消
        handleModalImport(param){
            if(param[0]) {
                console.log('导入成功')
            } else {
                console.log('导入失败')
            }
            this.importVisible = false
        }
    },
    components:{
        TableToolBar,
        addEditModal,
        delModal,
        importListModal,
        Pagination
    }
}
</script>-->
<template>
  <el-row class="warp">
    <el-col :span="24" class="warp-main box_table" v-loading="loading" element-loading-text="拼命加载中">
      <!--工具条-->
      <div class="table_tool">
        <div class="box_search">
          <el-form ref="form" :model="filter">
            <el-input v-model="filter.batchNo" placeholder="批次号" @keyup.enter.native="search" size="mini"></el-input>
            <el-date-picker v-model="filter.BeginDateTime" placeholder="开始时间" value-format="yyyy-MM-dd">
            </el-date-picker>
            <el-date-picker v-model="filter.EndDateTime" placeholder="结束时间" value-format="yyyy-MM-dd">
            </el-date-picker>
            <el-select v-model="filter.productId"  placeholder="请选择产品">
              <el-option
                v-for="item in productOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
            <el-select v-model="filter.equipmentId"  placeholder="请选择设备">
              <el-option
                v-for="item in equipmentOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
            <el-button type="primary" icon="el-icon-search" size="mini" @click="search" >搜索</el-button>
            <el-button type="primary" icon="el-icon-circle-plus-outline" style="float: right" size="mini" @click="showAddDialog" >导入</el-button>
          </el-form>
        </div>
      </div>
      <!--列表-->
      <el-table class="tableCss" :data="datalist" highlight-current-row @selection-change="selectInfos" stripe
                style="width: 100%;" :max-height="maxHeight">
        <el-table-column type="index" width="60">
        </el-table-column>
        <el-table-column prop="batchNo" label="批次号">
        </el-table-column>
        <el-table-column prop="productName" label="产品名称" >
        </el-table-column>
        <el-table-column prop="equipmentName" label="尺寸检测机">
        </el-table-column>
        <el-table-column prop="quantity" label="检测产品数量">
        </el-table-column>
        <el-table-column prop="beginDateTime" label="开始时间">
        </el-table-column>
        <el-table-column prop="endDateTime" label="结束时间">
        </el-table-column>
        <!--<el-table-column prop="description" label="描述">
        </el-table-column>-->
        <el-table-column label="操作" width="150">
          <template slot-scope="scope">
            <el-button size="small" @click="dimensionDetailjumpHtml(scope.row.batchNo)">详情</el-button>
            <el-button size="small" @click="dimensionSummaryjumpHtml(scope.row.batchNo)">汇总</el-button>
            <!-- <el-button type="danger" @click="del(scope.row.taskID)" size="small">删除</el-button> -->
          </template>
        </el-table-column>
      </el-table>
      <!--工具条-->
      <el-col :span="24" class="toolbar">
        <Pagination
          @handleCurrentChange="handleCurrentChange"
          @handleSizeChange="maxResultCountSelect"
          :page-size="maxResultCount"
          :page-sizes="pageSelectList"
          :total="totalCount">
        </Pagination>
      </el-col>
      <el-dialog  :visible.sync ="addFormVisible"  :before-close="closeAddDialog">
        <div slot="title">导入数据</div>
        <el-form :model="addForm" label-width="120px" :rules="editFormRules" ref="addForm">
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
          <el-form-item label="批次号:" prop="userName">
            <el-input v-model="addForm.batchNo" auto-complete="off"></el-input>
          </el-form-item>

          <el-form-item label="产品:" prop="productId">
            <el-select v-model="addForm.productId"  placeholder="请选择">
              <el-option
                v-for="item in productOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="检测设备:" prop="equipmentId">
            <el-select v-model="addForm.equipmentId"  placeholder="请选择">
              <el-option
                v-for="item in equipmentOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
          </el-form-item>
        </el-form>
        <div slot="footer" class="dialog-footer">
          <el-button @click.native="closeAddDialog">取消</el-button>
          <el-button type="primary" @click.native="impartData" :loading="loading">保存</el-button>
        </div>
      </el-dialog>
    </el-col>
  </el-row>
</template>
<script>
  import DimensionView from '../../../View/DimensionView';
  export default new DimensionView()
</script>
<style lang="stylus" scope>
@import '../../../common/common.stylus'
</style>
