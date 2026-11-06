let currentTranslations = {};
let dataTable = null;

$(document).ready(function () {
    
    loadLanguage('es');

    $('#languageSelector').on('change', function () {
        const selectedLang = $(this).val();
        loadLanguage(selectedLang);
    });

    $('#btnNewDeposit').on('click', openNewDepositModal);

    $('#depositsTable').on('click', '.btn-reconcile', function () {
        const depositId = $(this).data('id');
        openReconcileModal(depositId);
    })

    $('#depositsTable').on('click', '.btn-audit', function () {
        const depositId = $(this).data('id');
        openAuditModal(depositId);
    });
});

function loadLanguage(lang) {
    $.getJSON(`i18n/${lang}.json`)
        .done(function (data) {
            currentTranslations = data;

            if (dataTable !== null) {
                dataTable.destroy();
            }

            applyTranslations(data);
            initDataTable();
        })
        .fail(function (jqxhr, textStatus, error) {
            console.error("Error loading the language dictionary: ", error);
        });
}

function applyTranslations(translations) {
    
    $('#lblDashboardTitle').text(translations.dashboard.title);
    $('#lblLanguage').text(translations.dashboard.languageLabel);

    $('#languageSelector option[value="es"]').text(translations.languages.es);
    $('#languageSelector option[value="en"]').text(translations.languages.en);

    $('#btnNewDeposit').text(translations.dashboard.newDepositBtn);

    $('#thDepositNumber').text(translations.dashboard.depositNumber);
    $('#thExpectedAmount').text(translations.dashboard.expectedAmount);
    $('#thActualAmount').text(translations.dashboard.actualAmount);
    $('#thStatus').text(translations.dashboard.status);
    $('#thActions').text(translations.dashboard.actions);

    $('#lblMetricPending').text(translations.metrics.pending);
    $('#lblMetricReconciled').text(translations.metrics.reconciled);
    $('#lblMetricShortages').text(translations.metrics.shortages);
    $('#lblMetricOverages').text(translations.metrics.overages);
    $('#lblMetricExpected').text(translations.metrics.expected);
    $('#lblMetricActual').text(translations.metrics.actual);
}

function initDataTable() {
    dataTable = $('#depositsTable').DataTable({
        ajax: {
            url: '/api/deposits',
            dataSrc: ''
        },
        language: currentTranslations.dataTables,
        lengthMenu: [5, 10, 20],
        pageLength: 5,
        dom: 'B<"clear">lfrtip',
        buttons: [
            {
                extend: 'csvHtml5',
                text: currentTranslations.dashboard.exportCsvBtn,
                className: 'btn btn-secondary btn-sm mb-3',
                bom: true,
                exportOptions: {
                    columns: [0, 1, 2, 3]
                }
            }
        ],
        columns: [
            { data: 'depositNumber' },
            {
                data: 'expectedAmount',
                render: $.fn.dataTable.render.number(',', '.', 2, '$')
            },
            {
                data: 'actualAmount',
                render: $.fn.dataTable.render.number(',', '.', 2, '$')
            },
            {
                data: 'status',
                render: function (data) {
                    const statusKey = data.toLowerCase();
                    return currentTranslations.status[statusKey] || data;
                }
            },
            {
                data: null,
                orderable: false,
                className: 'text-center',
                render: function (data, type, row) {
                    return `<div class="btn-group" role="group">
                            <button class="btn btn-sm btn-success btn-reconcile" data-id="${row.depositId}">
                                ${currentTranslations.dashboard.reconcileBtn}
                            </button>
                            <button class="btn btn-sm btn-info btn-audit text-white" data-id="${row.depositId}" title="Audit Trail">
                                ${currentTranslations.dashboard.auditBtn}
                            </button>
                        </div>`;
                }
            }
        ]
    });

    loadDashboardMetrics();
}

function openNewDepositModal() {
    const t = currentTranslations.newDepositModal;

    Swal.fire({
        title: t.title,
        html: `
            <input id="swal-store" class="swal2-input" placeholder="${t.storeNumber}">
            <input id="swal-deposit" class="swal2-input" placeholder="${t.depositNumber}">
            <input id="swal-amount" type="number" step="0.01" class="swal2-input" placeholder="${t.expectedAmount}">
        `,
        showCancelButton: true,
        confirmButtonText: t.save,
        cancelButtonText: t.cancel,
        focusConfirm: false,
        allowOutsideClick: false,
        allowEscapeKey: false,
        preConfirm: () => {
            
            const store = document.getElementById('swal-store').value;
            const deposit = document.getElementById('swal-deposit').value;
            const amount = document.getElementById('swal-amount').value;

            if (!store || !deposit || !amount) {
                Swal.showValidationMessage(t.validationError);
                return false;
            }

            return {
                depositNumber: deposit,
                storeNumber: store,
                expectedAmount: parseFloat(amount),
                depositDate: new Date().toISOString()
            };
        }
    }).then((result) => {
        if (result.isConfirmed) {
            
            $.ajax({
                url: '/api/deposits',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(result.value),
                success: function () {
                    Swal.fire(t.successTitle, t.successMessage, 'success');

                    dataTable.ajax.reload(null, false);
                    loadDashboardMetrics();
                },
                error: function (xhr) {
                    Swal.fire(t.errorTitle, xhr.responseText || 'Error', 'error');
                }
            });
        }
    });
}

function openReconcileModal(depositId) {
    
    const t = currentTranslations.reconcileModal;

    Swal.fire({
        title: t.title,
        html: `<input id="swal-actual-amount" type="number" step="0.01" class="swal2-input" placeholder="${t.actualAmount}">`,
        showCancelButton: true,
        confirmButtonText: t.save,
        cancelButtonText: t.cancel,
        focusConfirm: false,
        allowOutsideClick: false,
        allowEscapeKey: false,
        preConfirm: () => {
            const actualAmount = document.getElementById('swal-actual-amount').value;

            if (!actualAmount) {
                Swal.showValidationMessage(t.validationError);
                return false;
            }

            return parseFloat(actualAmount);
        }
    }).then((result) => {
        if (result.isConfirmed) {
            const actualAmount = result.value;

            $.ajax({
                url: '/api/deposits/${depositId}/reconcile',
                type: 'PUT',
                contentType: 'application/json',
                data: JSON.stringify({
                    depositId: depositId,
                    actualAmount: actualAmount,
                    userId: "admin"
                }),
                success: function () {
                    Swal.fire(t.successTitle, t.successMessage, 'success');

                    dataTable.ajax.reload(null, false);
                    loadDashboardMetrics();
                },
                error: function (xhr) {
                    Swal.fire(t.errorTitle, xhr.responseText || 'Error', 'error');
                }
            });
        }
    });
}

function loadDashboardMetrics() {
    $.ajax({
        url: '/api/dashboard',
        type: 'GET',
        success: function (data) {
            $('#valPending').text(data.totalPending);
            $('#valReconciled').text(data.totalReconciled);
            $('#valShortages').text(data.totalShortages);
            $('#valOverages').text(data.totalOverages);

            const formatter = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' });

            $('#valExpected').text(formatter.format(data.totalExpectedAmount));
            $('#valActual').text(formatter.format(data.totalActualAmount));
        },
        error: function (xhr) {
            console.error("Error loading metrics: ", xhr);
        }
    });
}

function openAuditModal(depositId) {
    const t = currentTranslations.auditModal;

    $.ajax({
        url: `/api/deposits/${depositId}/audit`,
        type: 'GET',
        success: function (data) {
            let listHtml = '<ul class="list-group text-start" style="font-size: 0.9em;">';

            if (data.length === 0) {
                listHtml += `<li class="list-group-item">${t.empty}</li>`;
            } else {
                data.forEach(log => {
                    const date = new Date(log.timeStamp).toLocaleString();
                    listHtml += `
                        <li class="list-group-item">
                            <div class="d-flex w-100 justify-content-between">
                                <small class="text-muted">${date}</small>
                                <small class="text-primary fw-bold">${t.user}: ${log.userId}</small>
                            </div>
                            <div class="mt-1">
                                <strong>${t.action}:</strong> ${log.action} <br>
                                <strong>${t.change}:</strong> ${log.oldValues || 'N/A'} &rarr; ${log.newValues || 'N/A'}
                            </div>
                        </li>`;
                });
            }
            listHtml += '</ul>';

            Swal.fire({
                title: t.title,
                html: listHtml,
                width: '600px',
                showCloseButton: true,
                showConfirmButton: false
            });
        },
        error: function (xhr) {
            Swal.fire('Error', 'No se pudo cargar el historial de auditoría.', 'error');
        }
    });
}