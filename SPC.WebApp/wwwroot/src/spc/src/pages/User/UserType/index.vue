<template>
    <div>
        <div class="box_table">
            <TableToolBar :formData="formSearch"  @addModal="addModal(1)">
                <el-form-item slot="equipmentType">
                    <el-input
                              size="mini"
                              placeholder="类型搜索"
                              v-model="formSearch.UserTypeName">
                    </el-input>
                </el-form-item>
                <el-form-item slot="addModal" class="box_add">
                    <el-button type="primary" icon="el-icon-circle-plus-outline" size="mini" @click="addModal">添加</el-button>
                </el-form-item>
            </TableToolBar>
            <el-table
                :data="tableData.filter(data => !search || data.batch.toLowerCase().includes(search.toLowerCase()))"
                :default-sort = "{prop: 'number', order: 'descending'}"
                stripe
                style="width: 100%">
                <el-table-column
                label="类型编号"
                prop="UserTypeCode">
                </el-table-column>
                <el-table-column
                label="用户组类型"
                prop="UserTypeName">
                </el-table-column>
                <el-table-column
                label="权限管理"
                prop="ACL">
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
                UserTypeName:'',
            },
            search:'',
            // 表格的信息
            tableData: [
                {
                UserTypeCode: '001',
                UserTypeName: '管理员',
                ACL: '增加、删除、修改、查看   数据分类、档案管理、SPC分析',
                },
                {
                UserTypeCode: '002',
                UserTypeName: '操作员',
                ACL: '查看、增加、修改',
                },
            ],
            // 弹框的信息
            formModal: {
                UserTypeCode: '001',
                UserTypeName: '管理员',
                ACL: '增加、删除、修改、查看   数据分类、档案管理、SPC分析',
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
        Pagination
    }
}
</script>
<style lang="stylus" scope>
@import '../../../common/common.stylus'
</style>
