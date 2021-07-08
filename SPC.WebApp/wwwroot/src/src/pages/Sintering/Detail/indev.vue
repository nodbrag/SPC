<template>
    <div>
        <div class="box_table">
            <TableToolBar :formData="formSearch"  @addModal="addModal(1)">
                <el-input
                    slot="starttime"
                    size="mini"
                    placeholder="请输入开始时间"
                    suffix-icon="el-icon-date"
                    v-model="formSearch.starttime">
                </el-input>
                <el-input
                    slot="endtime"
                    size="mini"
                    placeholder="请输入结束时间"
                    suffix-icon="el-icon-date"
                    v-model="formSearch.endtime">
                </el-input>
                <div slot="addModal" class="box_add">
                    <el-button type="primary" icon="el-icon-circle-plus-outline" size="mini" @click="addModal">添加</el-button>
                </div>
            </TableToolBar>
            <el-table
                :data="tableData.filter(data => !search || data.batch.toLowerCase().includes(search.toLowerCase()))"
                :default-sort = "{prop: 'number', order: 'descending'}"
                stripe
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
                label="炉号"
                prop="furnaceNumber">
                </el-table-column>
                <el-table-column
                label="产品数量"
                prop="productQuantity">
                </el-table-column>
                <el-table-column
                label="烧结时间"
                prop="sinteringTime">
                </el-table-column>
                <el-table-column
                label="烧结盒"
                prop="sinteringBox">
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
        <!-- addEdit弹框 -->
        <addEditModal v-show="addVisible" :visible.sync="addVisible" :addOrEdit="addOrEdit" :formData="addOrEdit===1?{}:formModal" @handleModal="handleModal(arguments)" />
        
        <!-- delete弹框 -->
        <delModal v-show="delVisible" :visible.sync="delVisible" :rowId="rowId" @handleModalDel="handleModalDel(arguments)"></delModal>
    </div>
</template>
<script>
import TableToolBar from '../../../components/TableToolBar/TableToolBar.vue'
import addEditModal from './addEditModal.vue'
import delModal from '../../../components/ModalDelete/ModalDelete.vue'
import Pagination from '../../../components/Pagination/Pagination.vue'
export default {
    data() {
        return {
            // tableToolBar的信息
            formSearch: {
                batch:'',
                starttime:'',
                endtime:''
            },
            search:'',
            // 表格的信息
            tableData: [
                {
                batchC: 'APB-091',
                productName: '手机配件',
                furnaceNumber:'LH-801',
                productQuantity:'134,100',
                sinteringTime:'2019/05/09',
                sinteringBox:'BQ-130   BQ-130   BQ-130',
                },
                {
                batchC: 'APB-091',
                productName: '手机配件',
                furnaceNumber:'LH-801',
                productQuantity:'134,100',
                sinteringTime:'2019/05/09',
                sinteringBox:'BQ-130   BQ-130   BQ-130',
                },
                {
                batchC: 'APB-091',
                productName: '手机配件',
                furnaceNumber:'LH-801',
                productQuantity:'134,100',
                sinteringTime:'2019/05/09',
                sinteringBox:'BQ-130   BQ-130   BQ-130',
                }
            ],
            // 弹框的信息
            formModal: {
                batchC:'APB-091',
                productName:'手机配件',
                furnaceNumber:'LH-801',
                productQuantity:'134,100',
                sinteringTime:'2019/05/09',
                sinteringBox:'BQ-130   BQ-130   BQ-130'
            },
            addVisible: false, // 弹框是否显示,
            delVisible: false, // 删除弹框是否显示
            // 当前编辑的index
            rowId:0,
            // addOrEdit 确认添加还是编辑 1表示添加 2表示编辑
            addOrEdit: 1 
        }
    },
    methods: {
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
        }
    },
    components:{
        TableToolBar,
        addEditModal,
        delModal,
        Pagination
    }
}
</script>
<style lang="stylus" scope>
@import '../../../common/common.stylus'
</style>